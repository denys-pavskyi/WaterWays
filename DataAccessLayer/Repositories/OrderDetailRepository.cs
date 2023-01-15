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
    public class OrderDetailRepository: IOrderDetailRepository
    {
        private readonly WaterWaysDbContext _context;

        public OrderDetailRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(OrderDetail entity)
        {
            await _context.OrderDetails.AddAsync(entity);
        }

        public void Delete(OrderDetail entity)
        {
            _context.OrderDetails.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var OrderDetail = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(OrderDetail);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }



        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public void Update(OrderDetail entity)
        {
            _context.OrderDetails.Update(entity);

        }

        public async Task<OrderDetail> GetByIdWithDetailsAsync(int id)
        {
            return await _context.OrderDetails
                .Include(x => x.Order)
                    .ThenInclude(x => x.User)
                .Include(x => x.Product)
                    .ThenInclude(x => x.WaterPoint).FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<OrderDetail>> GetAllWithDetailsAsync()
        {
            return await _context.OrderDetails
                .Include(x => x.Order)
                    .ThenInclude(x => x.User)
                .Include(x => x.Product)
                    .ThenInclude(x => x.WaterPoint)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllWithNoTrackingAsync()
        {
            return await _context.OrderDetails.AsNoTracking().ToListAsync();
        }
    }
}
