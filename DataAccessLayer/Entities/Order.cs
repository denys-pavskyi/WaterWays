using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Order: BaseEntity
    {
        [Required, StringLength(150)]
        public string OrderText { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required, StringLength(15)]
        public string ContactPhone { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }


        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public bool IsToBeDelivered { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        public RegisteredUser User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        
    }

    public enum OrderStatus
    {
        Done,
        InProgress,
        Canceled,
        OnDelivery
    }
}
