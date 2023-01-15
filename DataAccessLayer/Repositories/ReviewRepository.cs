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
    public class ReviewRepository: IReviewRepository
    {
        private readonly WaterWaysDbContext _context;

        public ReviewRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(Review entity)
        {
            await _context.Reviews.AddAsync(entity);
        }

        public void Delete(Review entity)
        {
            _context.Reviews.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var Review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(Review);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }



        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public void Update(Review entity)
        {
            _context.Reviews.Update(entity);

        }

        public async Task<Review> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Reviews
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.WaterPointRepresentative)
                 .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.WaterPointRepresentative)
                 .Include(x => x.User)
                    .ThenInclude(x => x.Orders)
                 .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<Review>> GetAllWithDetailsAsync()
        {
            return await _context.Reviews
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.WaterPointRepresentative)
                 .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.WaterPointRepresentative)
                .Include(x => x.User)
                    .ThenInclude(x => x.Orders)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAllWithNoTrackingAsync()
        {
            return await _context.Reviews.AsNoTracking().ToListAsync();
        }
    }
}
