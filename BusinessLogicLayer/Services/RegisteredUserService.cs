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
    public class RegisteredUserService: IRegisteredUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RegisteredUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(RegisteredUserModel model)
        {
            ModelsValidation.RegisteredUserModelValidation(model);
            var mappedRegisteredUser = _mapper.Map<RegisteredUser>(model);

            await _unitOfWork.RegisteredUserRepository.AddAsync(mappedRegisteredUser);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.RegisteredUserRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RegisteredUserModel>> GetAllAsync()
        {
            IEnumerable<RegisteredUser> unmappedRegisteredUsers = await _unitOfWork.RegisteredUserRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<RegisteredUserModel>>(unmappedRegisteredUsers);
        }

        public async Task<RegisteredUserModel> GetByIdAsync(int id)
        {
            var unmappedRegisteredUser = await _unitOfWork.RegisteredUserRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<RegisteredUserModel>(unmappedRegisteredUser);
        }

        public async Task UpdateAsync(RegisteredUserModel model)
        {
            ModelsValidation.RegisteredUserModelValidation(model);
            var mapped = _mapper.Map<RegisteredUser>(model);
            _unitOfWork.RegisteredUserRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }
    }
}
