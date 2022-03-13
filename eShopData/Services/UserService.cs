using eShopData.Context;
using eShopData.Core.IData;
using eShopData.DTOs;
using eShopData.IService;

namespace eShopData.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<eShopContext> _unitOfWork;

        public UserService(IUnitOfWork<eShopContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public UserModel Insert(UserModel model)
        {
            throw new NotImplementedException();
        }

        public UserModel Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserModel Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
