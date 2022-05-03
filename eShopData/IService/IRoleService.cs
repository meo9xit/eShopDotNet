using eShopData.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.IService
{
    public interface IRoleService
    {
        Task<RoleModel> AddRoleAsync(RoleModel roleModel);
        Task<RoleModel> UpdateRoleAsync(RoleModel roleModel);
        Task DeleteRoleAsync(string roleId);
    }
}
