using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace ShopBridge.Models
{
    /// <summary>
    /// Model class to represent inventory_items table
    /// </summary>

    [Table("inventory_items")]
    public class InventoryItem
    {
        public Guid ID { get; set; }
        [Required]
        [BindRequired]
        [StringLength(512, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public DateTime ItemAddedOn { get; set; }
        [Required]
        public DateTime itemUpdatedOn { get; set; }
    }
}