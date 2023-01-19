using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderService: ICrud<OrderModel>
    {
        Task<IEnumerable<OrderModel>> GetAllByUserId(int userId);
        Task<int> AddAsyncReturnId(OrderModel model);

    }
}
