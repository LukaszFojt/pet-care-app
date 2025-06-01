using PetCareApplication.Domain.Entities.Common;

namespace PetCareApplication.Domain.Entities.User
{
    public class UserInfoEntity : DescNameIdEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public float Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Initials { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PicturePath { get; set; } = string.Empty;
        public float Stars { get; set; }
        public int CompletedOrders { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
