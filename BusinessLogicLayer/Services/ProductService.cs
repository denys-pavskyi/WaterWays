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
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(ProductModel model)
        {
            ModelsValidation.ProductModelValidation(model);
            var mappedProduct = _mapper.Map<Product>(model);

            await _unitOfWork.ProductRepository.AddAsync(mappedProduct);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.ProductRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            IEnumerable<Product> unmappedProducts = await _unitOfWork.ProductRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(unmappedProducts);
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            var unmappedProduct = await _unitOfWork.ProductRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<ProductModel>(unmappedProduct);
        }

        public async Task UpdateAsync(ProductModel model)
        {
            ModelsValidation.ProductModelValidation(model);
            var mapped = _mapper.Map<Product>(model);
            _unitOfWork.ProductRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllByWaterPointId(int waterPointId)
        {
            IEnumerable<Product> unmappedProducts = await _unitOfWork.ProductRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(unmappedProducts.Where(x => x.WaterPointId==waterPointId));
        }
    }
}
