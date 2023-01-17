using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Review : BaseEntity
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WaterPointId { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required]
        public DateTime UploadedOn { get; set; }

        [Required, Range(0, 5)]
        public int Rating { get; set; }

        [Required, StringLength(150)]
        public string ReviewText { get; set; }

        public WaterPoint WaterPoint { get; set; }
        public RegisteredUser User { get; set; }
    }
}
