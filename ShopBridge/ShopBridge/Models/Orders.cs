using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Models
{
    /// <summary>
    /// Model class to represent orders table
    /// </summary>

    [Table("orders")]
    public class Orders
    {
        public Guid ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid SupplierId { get; set; }
        [Required]
        public DateTime OrderDateAndTime { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; } = 1;

    }
}