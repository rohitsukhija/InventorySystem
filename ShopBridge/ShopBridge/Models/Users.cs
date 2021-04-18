using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Models
{
    /// <summary>
    /// Model class to represent shopping_users table
    /// </summary>

    [Table("shopping_user")]
    public class Users
    {
        public System.Guid ID { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string EmailOrPhone { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
    }
}