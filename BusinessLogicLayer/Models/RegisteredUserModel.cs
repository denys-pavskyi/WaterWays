using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class RegisteredUserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public RegisteredUserRole Role { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public List<int> OrderIds { get; set; }
        public List<int> ShoppingCartItemIds { get; set; }
        public List<int> ReviewIds { get; set; }
    }
}
