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
    public class ReviewService: IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(ReviewModel model)
        {
            ModelsValidation.ReviewModelValidation(model);
            var mappedReview = _mapper.Map<Review>(model);

            await _unitOfWork.ReviewRepository.AddAsync(mappedReview);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _unitOfWork.ReviewRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReviewModel>> GetAllAsync()
        {
            IEnumerable<Review> unmappedReviews = await _unitOfWork.ReviewRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<ReviewModel>>(unmappedReviews);
        }

        public async Task<ReviewModel> GetByIdAsync(int id)
        {
            var unmappedReview = await _unitOfWork.ReviewRepository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<ReviewModel>(unmappedReview);
        }

        public async Task UpdateAsync(ReviewModel model)
        {
            ModelsValidation.ReviewModelValidation(model);
            var mapped = _mapper.Map<Review>(model);
            _unitOfWork.ReviewRepository.Update(mapped);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReviewModel>> GetAllByWaterPointId(int waterPointId)
        {
            IEnumerable<Review> unmappedReviews = await _unitOfWork.ReviewRepository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<ReviewModel>>(unmappedReviews.Where(x => x.WaterPointId==waterPointId));
        }
    }
}
