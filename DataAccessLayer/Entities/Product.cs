using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Product : BaseEntity
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public ProductType Type { get; set; }

        [Required]
        public int WaterPointId { get; set; }

        [StringLength(50)]
        public string photoUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal QuantityAvailable { get; set; }

        public WaterPoint WaterPoint { get; set; }  

        public List<OrderDetail> OrderDetails { get; set; }
    }


    public enum ProductType
    {
        StillWater,
        SparklingWater,
        IndustrialWater,
        Other
    }
}
