using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IReviewService: ICrud<ReviewModel>
    {
        Task<IEnumerable<ReviewModel>> GetAllByWaterPointId(int waterPointId);
    }
}
