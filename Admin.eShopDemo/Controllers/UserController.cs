using Admin.eShopDemo.Models;
using eShopData.DTOs;
using eShopData.IService;
using Microsoft.AspNetCore.Mvc;

namespace Admin.eShopDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var listUser = await _userService.GetPaging(page);
            return View(new UserViewModel() { ListUsers = listUser.Data.Items.ToList() });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            var result = await _userService.Insert(model);
            return View(result);
        }
    }
}
