using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IRegisteredUserRepository RegisteredUserRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        IWaterPointRepository WaterPointRepository { get; }
        Task SaveAsync();
    }
}
