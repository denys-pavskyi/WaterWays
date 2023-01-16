using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Validations;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class VerificationDocumentService: IVerificationDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public VerificationDocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(VerificationDocumentModel model)
        {
            ModelsValidation.VerificationDocumentModelValidation(model);
            var mappedVerificationDocument = _mapper.Map<VerificationDocument>(model);

            await _unitOfWork.VerificationDocumentRepository.AddAsync(mappedVerificationDocument);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.VerificationDocumentRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<VerificationDocumentModel>> GetAllAsync()
        {
            IEnumerable<VerificationDocument> unmappedVerificationDocuments = await _unitOfWork.VerificationDocumentRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<VerificationDocumentModel>>(unmappedVerificationDocuments);
        }

        public async Task<VerificationDocumentModel> GetByIdAsync(int id)
        {
            var unmappedVerificationDocument = await _unitOfWork.VerificationDocumentRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<VerificationDocumentModel>(unmappedVerificationDocument);
        }

        public async Task UpdateAsync(VerificationDocumentModel model)
        {
            ModelsValidation.VerificationDocumentModelValidation(model);
            var mapped = _mapper.Map<VerificationDocument>(model);
            _unitOfWork.VerificationDocumentRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }
    }
}
