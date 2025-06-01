using Microsoft.EntityFrameworkCore;
using PetCareApplication.Application.Contracts.Common;
using PetCareApplication.Application.Queries.Common;
using PetCareApplication.Domain.Entities.Common;
using PetCareApplication.Domain.Entities.User;
using PetCareApplication.Infrastructure.DbContexts;

namespace PetCareApplication.Infrastructure.Repositories.Common
{
    public class CommonCrudRepository<T> : ICommonCrudRepository<T> where T : class, IDescNameIdEntity
    {
        private readonly PetCareApplicationDbContext _dbContext;
        private readonly IFilterHandler<T>? _filterHandler;

        public CommonCrudRepository(PetCareApplicationDbContext dbContext, IFilterHandler<T>? filterHandler = null)
        {
            _dbContext = dbContext;
            _filterHandler = filterHandler;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetTop(int count)
        {
            return await _dbContext.Set<T>().Take(count).ToListAsync();
        }

        public async Task<List<T>> GetBot(int count)
        {
            return await _dbContext.Set<T>().TakeLast(count).ToListAsync();
        }

        public async Task<List<T>> GetFiltered(List<FilterParameter> filters)
        {
            IQueryable<T> query = _dbContext.Set<T>().AsQueryable();

            if (_filterHandler != null)
            {
                return await _filterHandler.ApplyFiltersAsync(query, filters, _dbContext.Set<ConditionToUserTieEntity>().AsQueryable());
            }
            else
            {
                foreach (var filter in filters)
                {
                    if (filter.FilterName == "HasAnyId" && int.TryParse(filter.FilterValue.ToString(), out int idFilter))
                    {
                        query = query.Where(x => x.Id == idFilter);
                    }
                    else if (filter.FilterName == "ContainsName")
                    {
                        var val = filter.FilterValue.ToString() ?? "";
                        query = query.Where(x => EF.Functions.Like(x.Name, $"%{val}%"));
                    }
                    else if (filter.FilterName == "ContainsDescription")
                    {
                        var val = filter.FilterValue.ToString() ?? "";
                        query = query.Where(x => EF.Functions.Like(x.Description, $"%{val}%"));
                    }
                }
            }

            return await query.ToListAsync();
        }
    }
}
