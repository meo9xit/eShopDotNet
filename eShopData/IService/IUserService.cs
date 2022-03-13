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
        UserModel GetById(string id);
        UserModel Login(string username, string password);
        UserModel Insert(UserModel model);
        UserModel Update(UserModel model);
        void Delete(string id);
        
    }
}
