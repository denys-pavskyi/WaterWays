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
    public class WaterPointService: IWaterPointService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public WaterPointService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(WaterPointModel model)
        {
            ModelsValidation.WaterPointModelValidation(model);
            var mappedWaterPoint = _mapper.Map<WaterPoint>(model);

            await _unitOfWork.WaterPointRepository.AddAsync(mappedWaterPoint);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.WaterPointRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<WaterPointModel>> GetAllAsync()
        {
            IEnumerable<WaterPoint> unmappedWaterPoints = await _unitOfWork.WaterPointRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<WaterPointModel>>(unmappedWaterPoints);
        }

        public async Task<WaterPointModel> GetByIdAsync(int id)
        {
            var unmappedWaterPoint = await _unitOfWork.WaterPointRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<WaterPointModel>(unmappedWaterPoint);
        }

        public async Task UpdateAsync(WaterPointModel model)
        {
            ModelsValidation.WaterPointModelValidation(model);
            var mapped = _mapper.Map<WaterPoint>(model);
            _unitOfWork.WaterPointRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }
    }
}
