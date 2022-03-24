using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    [Table("user")]
    public class User : IdentityUser<Guid>
    { 
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
