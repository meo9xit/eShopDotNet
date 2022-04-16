namespace Admin.eShopDemo.Models.User
{
    public class UpdateUserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public UpdateUserViewModel(string name, string email, string userName)
        {
            FullName = name;
            Email = email;
            UserName = userName;
        }
    }
}
