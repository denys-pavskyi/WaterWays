using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IWaterPointRepository: IRepository<WaterPoint>
    {
        Task<IEnumerable<WaterPoint>> GetAllWithDetailsAsync();
        Task<WaterPoint> GetByIdWithDetailsAsync(int id);
    }
}
