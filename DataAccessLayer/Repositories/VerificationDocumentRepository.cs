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
    public class VerificationDocumentRepository: IVerificationDocumentRepository
    {
        private readonly WaterWaysDbContext _context;

        public VerificationDocumentRepository(WaterWaysDbContext internetPhotoAlbumDbContext)
        {
            _context = internetPhotoAlbumDbContext;
        }

        public async Task AddAsync(VerificationDocument entity)
        {
            await _context.VerificationDocuments.AddAsync(entity);
        }

        public void Delete(VerificationDocument entity)
        {
            _context.VerificationDocuments.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var VerificationDocument = await _context.VerificationDocuments.FindAsync(id);
            _context.VerificationDocuments.Remove(VerificationDocument);
        }

        public async Task<IEnumerable<VerificationDocument>> GetAllAsync()
        {
            return await _context.VerificationDocuments.ToListAsync();
        }



        public async Task<VerificationDocument> GetByIdAsync(int id)
        {
            return await _context.VerificationDocuments.FindAsync(id);
        }

        public void Update(VerificationDocument entity)
        {
            _context.VerificationDocuments.Update(entity);

        }

        public async Task<VerificationDocument> GetByIdWithDetailsAsync(int id)
        {
            return await _context.VerificationDocuments
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.User)
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.Reviews)
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.Products)
                .Include(x => x.User)
                    .ThenInclude(x => x.Orders)
                .Include(x => x.User)
                    .ThenInclude(x => x.ShoppingCartItems)
                .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<VerificationDocument>> GetAllWithDetailsAsync()
        {
            return await _context.VerificationDocuments
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.User)
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.Reviews)
                .Include(x => x.WaterPoint)
                    .ThenInclude(x => x.Products)
                .Include(x => x.User)
                    .ThenInclude(x => x.Orders)
                .Include(x => x.User)
                    .ThenInclude(x => x.ShoppingCartItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<VerificationDocument>> GetAllWithNoTrackingAsync()
        {
            return await _context.VerificationDocuments.AsNoTracking().ToListAsync();
        }
    }
}
