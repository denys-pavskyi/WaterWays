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

        public async Task<decimal> GetTotalPriceOfItems()
        {
            List<ShoppingCart> unmappedShoppingCarts = await _unitOfWork.ShoppingCartRepository.GetAllWithNoTrackingAsync() as List<ShoppingCart>;
            decimal totalPrice = 0;
            for(int i=0;i< unmappedShoppingCarts.Count(); i++)
            {
                totalPrice += unmappedShoppingCarts[i].TotalPrice;
            }
            return totalPrice;
        }

        public async Task<bool> ShoppingCartToOrderDetails(int userId, int orderId){
            List<ShoppingCart> unmappedShoppingCarts = await _unitOfWork.ShoppingCartRepository.GetAllWithNoTrackingAsync() as List<ShoppingCart>;

            List<Product> products = (await _unitOfWork.ProductRepository.GetAllWithNoTrackingAsync()).ToList();
            
            unmappedShoppingCarts = unmappedShoppingCarts.Where(x => x.UserId == userId).ToList();
            for (int i = 0; i < unmappedShoppingCarts.Count(); i++)
            {
                Product prod = products.FirstOrDefault(x => x.Id == unmappedShoppingCarts[i].ProductId);

                decimal newQuantity = prod.QuantityAvailable - unmappedShoppingCarts[i].Quantity;
                if(newQuantity >= 0)
                {

                    prod.QuantityAvailable = newQuantity;

                    _unitOfWork.ProductRepository.Update(prod);

                    OrderDetail newOrderDetail = new OrderDetail()
                    {
                        OrderId = orderId,
                        ProductId = unmappedShoppingCarts[i].ProductId,
                        Quantity = unmappedShoppingCarts[i].Quantity,
                        TotalPrice = unmappedShoppingCarts[i].TotalPrice,
                        UnitPrice = unmappedShoppingCarts[i].UnitPrice
                    };
                    await _unitOfWork.OrderDetailRepository.AddAsync(newOrderDetail);
                    await _unitOfWork.ShoppingCartRepository.DeleteByIdAsync(unmappedShoppingCarts[i].Id);
                }

                



                
            }
            await _unitOfWork.SaveAsync();



            return true;
        }

    }
}
