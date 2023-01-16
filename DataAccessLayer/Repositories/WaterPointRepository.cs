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
    public class WaterPointRepository: IWaterPointRepository
    {
        private readonly WaterWaysDbContext _context;

        public WaterPointRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(WaterPoint entity)
        {
            await _context.WaterPoints.AddAsync(entity);
        }

        public void Delete(WaterPoint entity)
        {
            _context.WaterPoints.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var WaterPoint = await _context.WaterPoints.FindAsync(id);
            _context.WaterPoints.Remove(WaterPoint);
        }

        public async Task<IEnumerable<WaterPoint>> GetAllAsync()
        {
            return await _context.WaterPoints.ToListAsync();
        }



        public async Task<WaterPoint> GetByIdAsync(int id)
        {
            return await _context.WaterPoints.FindAsync(id);
        }

        public void Update(WaterPoint entity)
        {
            _context.WaterPoints.Update(entity);

        }

        public async Task<WaterPoint> GetByIdWithDetailsAsync(int id)
        {
            return await _context.WaterPoints
                .Include(x => x.User)
                    .ThenInclude(x => x.Orders)
                 .Include(x => x.User)
                    .ThenInclude(x => x.ShoppingCartItems)
                .Include(x => x.Reviews)
                .Include(x => x.Products)
                 .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<WaterPoint>> GetAllWithDetailsAsync()
        {
            return await _context.WaterPoints
                .Include(x => x.User)
                    .ThenInclude(x => x.Orders)
                 .Include(x => x.User)
                    .ThenInclude(x => x.ShoppingCartItems)
                .Include(x => x.Reviews)
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<IEnumerable<WaterPoint>> GetAllWithNoTrackingAsync()
        {
            return await _context.WaterPoints.AsNoTracking().ToListAsync();
        }
    }
}
