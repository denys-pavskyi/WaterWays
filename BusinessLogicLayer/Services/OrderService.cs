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
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(OrderModel model)
        {
            ModelsValidation.OrderModelValidation(model);
            var mappedOrder = _mapper.Map<Order>(model);

            await _unitOfWork.OrderRepository.AddAsync(mappedOrder);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.OrderRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            IEnumerable<Order> unmappedOrders = await _unitOfWork.OrderRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<OrderModel>>(unmappedOrders);
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            var unmappedOrder = await _unitOfWork.OrderRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<OrderModel>(unmappedOrder);
        }

        public async Task UpdateAsync(OrderModel model)
        {
            ModelsValidation.OrderModelValidation(model);
            var mapped = _mapper.Map<Order>(model);
            _unitOfWork.OrderRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }
    }
}
