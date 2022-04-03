using Admin.eShopDemo.Models;
using Admin.eShopDemo.Models.User;
using eShopData.DTOs;
using eShopData.DTOs.User;
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
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _userService.Insert(model);
            return View(result);
        }

        [HttpGet("/user/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetById(id);
            return View(new UpdateUserViewModel(user.Data.FullName, user.Data.Email));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                await _userService.Update(model);
                return RedirectToAction("Index","User");
            }
            return View(new UpdateUserViewModel(model.FullName, model.Email));
        }
    }
}
