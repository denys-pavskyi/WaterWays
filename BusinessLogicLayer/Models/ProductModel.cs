using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string photoUrl { get; set; }

        public ProductType Type { get; set; }

        public int WaterPointId { get; set; }

        public decimal Price { get; set; }

        public decimal QuantityAvailable { get; set; }
    }
}
