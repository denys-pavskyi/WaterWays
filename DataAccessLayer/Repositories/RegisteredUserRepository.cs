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
    public class RegisteredUserRepository: IRegisteredUserRepository
    {

        private readonly WaterWaysDbContext _context;

        public RegisteredUserRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(RegisteredUser entity)
        {
            await _context.RegisteredUsers.AddAsync(entity);
        }

        public void Delete(RegisteredUser entity)
        {
            _context.RegisteredUsers.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var RegisteredUser = await _context.RegisteredUsers.FindAsync(id);
            _context.RegisteredUsers.Remove(RegisteredUser);
        }

        public async Task<IEnumerable<RegisteredUser>> GetAllAsync()
        {
            return await _context.RegisteredUsers.ToListAsync();
        }



        public async Task<RegisteredUser> GetByIdAsync(int id)
        {
            return await _context.RegisteredUsers.FindAsync(id);
        }

        public void Update(RegisteredUser entity)
        {
            _context.RegisteredUsers.Update(entity);

        }

        public async Task<RegisteredUser> GetByIdWithDetailsAsync(int id)
        {
            return await _context.RegisteredUsers
                .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderDetails)
                .Include(x => x.ShoppingCartItems)
                    .ThenInclude(x => x.Product)
                 .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<RegisteredUser>> GetAllWithDetailsAsync()
        {
            return await _context.RegisteredUsers
                .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderDetails)
                .Include(x => x.ShoppingCartItems)
                    .ThenInclude(x => x.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<RegisteredUser>> GetAllWithNoTrackingAsync()
        {
            return await _context.RegisteredUsers.AsNoTracking().ToListAsync();
        }
    }
}
