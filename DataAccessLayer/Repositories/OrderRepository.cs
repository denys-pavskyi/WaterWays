using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly WaterWaysDbContext _context;

        public OrderRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(Order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }



        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);

        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Orders
                .Include(x => x.User)
                    .ThenInclude(x => x.ShoppingCartItems)
                .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await _context.Orders
                .Include(x => x.User)
                    .ThenInclude(x => x.ShoppingCartItems)
                .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllWithNoTrackingAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }
    }
}
