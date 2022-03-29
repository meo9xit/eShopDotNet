using eShopData.DTOs;

namespace Admin.eShopDemo.Models
{
    public class UserViewModel
    {
        public IEnumerable<UserModel> ListUsers { get; set; } = new List<UserModel>();
    }
}
