using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopData.Entities
{
    [Table("role")]
    public class Role : IdentityRole<Guid>
    {
    }
}
