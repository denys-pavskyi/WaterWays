using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class VerificationDocument: BaseEntity
    {
       [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WaterPointId { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required]
        public string DocumentLink { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public VerificationStatus VerificationStatus { get; set; }

        public WaterPoint WaterPoint { get; set; }
        public RegisteredUser User { get; set; }

    }

    public enum VerificationStatus
    {
        Approved,
        Declined,
        OnReview
    }
}
