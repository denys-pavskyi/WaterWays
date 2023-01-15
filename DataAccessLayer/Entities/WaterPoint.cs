using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class WaterPoint: BaseEntity
    {
        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(150)]
        public string Description { get; set; }

        [Required]
        public WaterPointType WaterPointType { get; set; }

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required, StringLength(80)]
        public string Address { get; set; }

        [Required, Range(0d,5d)]
        public double Rating { get; set; }

        [Required]
        public bool IsVerified { get; set; }

        [Required]
        public bool HasOrdering { get; set; }

        [Required]
        public bool HasDelivery { get; set; }

        [Required]
        public bool HasSearchPriority { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RepresentativeId { get; set; }


        public RegisteredUser WaterPointRepresentative { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Product> Products { get; set; }


    }

    public enum WaterPointType
    {
        PumpStation,
        WaterDelivery,
        Shop,
        EmergencyWaterTransportation,
        Other
    }
}
