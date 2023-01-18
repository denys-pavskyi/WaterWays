using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IShoppingCartService: ICrud<ShoppingCartModel>
    {
        Task<IEnumerable<ShoppingCartModel>> GetAllByUserId(int userId);
        Task<int> FindByProductAndUserId(int productId, int userId);
    }
}
