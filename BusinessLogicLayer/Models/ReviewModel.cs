using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public int WaterPointId { get; set; }

        public int UserId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }

    }
}
