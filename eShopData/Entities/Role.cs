using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopData.Entities
{
    [Table("role")]
    public class Role
    {
        [Key]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
