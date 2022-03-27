using AutoMapper;
using eShopData.Context;
using eShopData.Core.Collections;
using eShopData.Core.IData;
using eShopData.DTOs;
using eShopData.DTOs.User;
using eShopData.Entities;
using eShopData.IService;
using eShopData.ServiceResult;
using eShopData.Utils.Constant;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eShopData.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IConfiguration config,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<Result<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ErrorResult<bool>("User không tồn tại");
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new SuccessResult<bool>(ResultMessage.DeleteSuccess);
            return new ErrorResult<bool>(ResultMessage.DeleteFailure);
        }

        public async Task<Result<UserModel>> GetById(Guid id)
        {
            User entity = await _userManager.FindByIdAsync(id.ToString());
            if (entity == null) return new ErrorResult<UserModel>();
            return new SuccessResult<UserModel>() { Data = _mapper.Map<UserModel>(entity) };
        }

        public async Task<Result<UserModel>> Insert(UserModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                return new ErrorResult<UserModel>(ResultMessage.UserExisted);
            }
            
            var entity = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(entity);
            if(!result.Succeeded)
                return new ErrorResult<UserModel>();
          
            var userModel = _mapper.Map<UserModel>(user);
            return new SuccessResult<UserModel>() { Data = userModel };
        }

        public async Task<Result<string>> AuthentiCate(LoginModel login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if(user == null)
                return new ErrorResult<string>(ResultMessage.UserNotFound);

            var result = await _signInManager.PasswordSignInAsync(user ,login.Password, login.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded) 
                return new ErrorResult<string>(ResultMessage.PasswordIncorrect);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Role, string.Join(',', roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            return new SuccessResult<string>() { Data = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        public async Task<Result<UserModel>> Update(UserModel model)
        {
            var entity = await _userManager.FindByIdAsync(model.Id.ToString());
            if (entity == null)
                return new ErrorResult<UserModel>();
            _mapper.Map(model, entity);
            var result = await _userManager.UpdateAsync(entity);
            if (!result.Succeeded)
                return new ErrorResult<UserModel>();
            return new SuccessResult<UserModel>() { Data = model};
        }

        public async Task<Result<IPagedList<UserModel>>> GetPaging(int page = 1)
        {
            var list = await _userRepository.GetPagedListAsync(p => !p.IsDeleted, null, null, page-1);
            var ret = _mapper.Map<IPagedList<UserModel>>(list);
            return new SuccessResult<IPagedList<UserModel>> { Data = ret};
        }
    }
}
