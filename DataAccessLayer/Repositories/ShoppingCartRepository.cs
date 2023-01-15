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
    public class ShoppingCartRepository: IShoppingCartRepository
    {
        private readonly WaterWaysDbContext _context;

        public ShoppingCartRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(ShoppingCart entity)
        {
            await _context.ShoppingCarts.AddAsync(entity);
        }

        public void Delete(ShoppingCart entity)
        {
            _context.ShoppingCarts.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ShoppingCart = await _context.ShoppingCarts.FindAsync(id);
            _context.ShoppingCarts.Remove(ShoppingCart);
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync()
        {
            return await _context.ShoppingCarts.ToListAsync();
        }



        public async Task<ShoppingCart> GetByIdAsync(int id)
        {
            return await _context.ShoppingCarts.FindAsync(id);
        }

        public void Update(ShoppingCart entity)
        {
            _context.ShoppingCarts.Update(entity);

        }

        public async Task<ShoppingCart> GetByIdWithDetailsAsync(int id)
        {
            return await _context.ShoppingCarts
                .Include(x => x.Product)
                    .ThenInclude(x => x.WaterPoint)
                 .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithDetailsAsync()
        {
            return await _context.ShoppingCarts
                .Include(x => x.Product)
                    .ThenInclude(x => x.WaterPoint)
                .ToListAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllWithNoTrackingAsync()
        {
            return await _context.ShoppingCarts.AsNoTracking().ToListAsync();
        }
    }
}
