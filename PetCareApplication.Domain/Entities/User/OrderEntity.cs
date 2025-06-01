using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.User
{
    public class OrderEntity : DescNameIdEntity
    {
        public string Code { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Stars { get; set; }
        public float Cost { get; set; }
        public string EmployerId { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        NotStarted = 0,
        Started = 1,
        Completed = 2,
        Canceled = 3
    }
}
