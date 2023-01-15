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
    public class ProductRepository: IProductRepository
    {

        private readonly WaterWaysDbContext _context;

        public ProductRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            _context.Products.Remove(Product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }



        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);

        }

        public async Task<Product> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Products
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.WaterPointRepresentative)
                 .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.Reviews)
                 .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            return await _context.Products
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.WaterPointRepresentative)
                 .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.Reviews)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithNoTrackingAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }
    }
}
