using eShopData.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.IService
{
    public interface IUserService
    {
        Task<UserModel> GetById(string id);
        Task<UserModel> Login(string username, string password);
        Task<UserModel> Insert(UserModel model);
        Task<UserModel> Update(UserModel model);
        void Delete(UserModel model);
        
    }
}
