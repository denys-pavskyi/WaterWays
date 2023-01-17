using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class VerificationDocumentModel
    {
        public int WaterPointId { get; set; }

        public int UserId { get; set; }

        public string DocumentLink { get; set; }

        public DateTime UploadDate { get; set; }

        public VerificationStatus VerificationStatus { get; set; }
    }
}
