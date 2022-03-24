using eShopData.DTOs;
using eShopData.DTOs.User;
using eShopData.ServiceResult;

namespace eShopData.IService
{
    public interface IUserService
    {
        Task<Result<UserModel>> GetById(Guid id);
        Task<Result<string>> AuthentiCate(LoginModel login);
        Task<Result<UserModel>> Insert(UserModel model);
        Task<Result<UserModel>> Update(UserModel model);
        Task<Result<bool>> Delete(UserModel model);
        
    }
}
