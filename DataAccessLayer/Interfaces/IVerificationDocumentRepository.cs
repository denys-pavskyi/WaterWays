using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IVerificationDocumentRepository: IRepository<VerificationDocument>
    {
        Task<IEnumerable<VerificationDocument>> GetAllWithDetailsAsync();
        Task<VerificationDocument> GetByIdWithDetailsAsync(int id);
    }
}
