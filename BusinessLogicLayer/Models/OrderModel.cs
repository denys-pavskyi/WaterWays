using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string OrderText { get; set; }

        public int UserId { get; set; }

        public string ContactPhone { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsToBeDelivered { get; set; }

        
        public OrderStatus OrderStatus { get; set; }

        public List<int> OrderDetailIds { get; set; }
    }
}
