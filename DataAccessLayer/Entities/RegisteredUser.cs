using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class RegisteredUser : BaseEntity
    {
        [Required, StringLength(60)]
        public string FirstName { get; set; }

        [Required, StringLength(60)]
        public string LastName { get; set; }

        [Required, StringLength(20)]
        public string UserName { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required]
        public RegisteredUserRole Role { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Phone { get; set; }

        [Required, StringLength(80)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
        public List<ShoppingCart> ShoppingCartItems { get; set;}
        public List<Review> Reviews { get; set; }
    }

    public enum RegisteredUserRole
    {
        RegisteredUser,
        WaterPointRepresentative,
        Admin
    }
}
