namespace Admin.eShopDemo.Models.User
{
    public class UpdateUserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public UpdateUserViewModel(string name, string email)
        {
            FullName = name;
            Email = email;
        }
    }
}
