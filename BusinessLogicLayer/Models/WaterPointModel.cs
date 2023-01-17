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
    public class WaterPointModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public WaterPointType WaterPointType { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public double Rating { get; set; }

        public bool IsVerified { get; set; }

        public bool HasOrdering { get; set; }

        public bool HasOwnDelivery { get; set; }

        public bool HasSearchPriority { get; set; }

        public int UserId { get; set; }

        public int? VerificationDocumentId { get; set; }


        public List<int> ReviewIds { get; set; }

        public List<int> ProductIds { get; set; }

    }
}
