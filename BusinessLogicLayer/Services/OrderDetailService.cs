using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Validations;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class OrderDetailService: IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(OrderDetailModel model)
        {
            ModelsValidation.OrderDetailModelValidation(model);
            var mappedOrderDetail = _mapper.Map<OrderDetail>(model);

            await _unitOfWork.OrderDetailRepository.AddAsync(mappedOrderDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.OrderDetailRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OrderDetailModel>> GetAllAsync()
        {
            IEnumerable<OrderDetail> unmappedOrderDetails = await _unitOfWork.OrderDetailRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<OrderDetailModel>>(unmappedOrderDetails);
        }

        public async Task<OrderDetailModel> GetByIdAsync(int id)
        {
            var unmappedOrderDetail = await _unitOfWork.OrderDetailRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<OrderDetailModel>(unmappedOrderDetail);
        }

        public async Task UpdateAsync(OrderDetailModel model)
        {
            ModelsValidation.OrderDetailModelValidation(model);
            var mapped = _mapper.Map<OrderDetail>(model);
            _unitOfWork.OrderDetailRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }
    }
}
