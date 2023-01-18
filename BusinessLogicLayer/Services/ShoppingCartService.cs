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
    public class ShoppingCartService: IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ShoppingCartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(ShoppingCartModel model)
        {
            ModelsValidation.ShoppingCartModelValidation(model);
            var mappedShoppingCart = _mapper.Map<ShoppingCart>(model);

            await _unitOfWork.ShoppingCartRepository.AddAsync(mappedShoppingCart);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.ShoppingCartRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ShoppingCartModel>> GetAllAsync()
        {
            IEnumerable<ShoppingCart> unmappedShoppingCarts = await _unitOfWork.ShoppingCartRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<ShoppingCartModel>>(unmappedShoppingCarts);
        }

        public async Task<ShoppingCartModel> GetByIdAsync(int id)
        {
            var unmappedShoppingCart = await _unitOfWork.ShoppingCartRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<ShoppingCartModel>(unmappedShoppingCart);
        }

        public async Task UpdateAsync(ShoppingCartModel model)
        {
            ModelsValidation.ShoppingCartModelValidation(model);
            var mapped = _mapper.Map<ShoppingCart>(model);
            _unitOfWork.ShoppingCartRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ShoppingCartModel>> GetAllByUserId(int userId)
        {
            IEnumerable<ShoppingCart> unmappedShoppingCarts = await _unitOfWork.ShoppingCartRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<ShoppingCartModel>>(unmappedShoppingCarts.Where(x => x.UserId == userId));
        }

        public async Task<int> FindByProductAndUserId(int productId, int userId)
        {
            IEnumerable<ShoppingCart> unmappedShoppingCarts = await _unitOfWork.ShoppingCartRepository.GetAllWithNoTrackingAsync();

            ShoppingCart unmappedShoppingCart = unmappedShoppingCarts.Where(x => x.UserId==userId && x.ProductId==productId).FirstOrDefault();

            if(unmappedShoppingCart!=null)
            {
                return unmappedShoppingCart.Id;
            }
            else
            {
                return -1;
            }
        }
    }
}
