using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Models
{
    /// <summary>
    /// Model class to represent suppliers table
    /// </summary>

    [Table("suppliers")]
    public class Supplier
    {
        public System.Guid ID { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string SupplierName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string EmailOrPhone { get; set; }
    }
}