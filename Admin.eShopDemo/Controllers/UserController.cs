using Admin.eShopDemo.Models;
using Admin.eShopDemo.Models.User;
using eShopData.DTOs;
using eShopData.DTOs.User;
using eShopData.IService;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("users")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var listUser = await _userService.GetPaging(page);
            return View(new UserViewModel() { ListUsers = listUser.Data.Items.ToList() });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            return RedirectToAction("index");
        }

        [AllowAnonymous]
        [HttpGet("user/register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _userService.Insert(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetById(id);
            return View(new UpdateUserViewModel(user.Data.FullName, user.Data.Email, user.Data.UserName));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }
            var result = await _userService.Update(model);
            if (result.Success)
                return RedirectToAction("Index");
            return StatusCode(500);
        }
    }
}
