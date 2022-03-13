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
    public class User
    { 
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get;set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
