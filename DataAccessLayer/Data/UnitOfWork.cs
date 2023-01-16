using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly WaterWaysDbContext dbContext;
        private OrderDetailRepository orderDetailRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private ReviewRepository reviewRepository;
        private ShoppingCartRepository shoppingCartRepository;
        private RegisteredUserRepository registeredUserRepository;
        private WaterPointRepository waterPointRepository;
        private VerificationDocumentRepository verificationDocumentRepository;

        public UnitOfWork(WaterWaysDbContext context)
        {
            dbContext = context;
        }

        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                if (orderDetailRepository == null)
                {
                    orderDetailRepository = new OrderDetailRepository(dbContext);
                }
                return orderDetailRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(dbContext);
                }
                return orderRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                   productRepository = new ProductRepository(dbContext);
                }
                return productRepository;
            }
        }


        public IReviewRepository ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                {
                    reviewRepository = new ReviewRepository(dbContext);
                }
                return reviewRepository;
            }
        }

        public IShoppingCartRepository ShoppingCartRepository
        {
            get
            {
                if (shoppingCartRepository == null)
                {
                    shoppingCartRepository = new ShoppingCartRepository(dbContext);
                }
                return shoppingCartRepository;
            }
        }

        public IWaterPointRepository WaterPointRepository
        {
            get
            {
                if (waterPointRepository == null)
                {
                    waterPointRepository = new WaterPointRepository(dbContext);
                }
                return waterPointRepository;
            }
        }

        public IVerificationDocumentRepository VerificationDocumentRepository
        {
            get
            {
                if (verificationDocumentRepository == null)
                {
                   verificationDocumentRepository = new VerificationDocumentRepository(dbContext);
                }
                return verificationDocumentRepository;
            }
        }

        public IRegisteredUserRepository RegisteredUserRepository
        {
            get
            {
                if (registeredUserRepository == null)
                {
                    registeredUserRepository = new RegisteredUserRepository(dbContext);
                }
                return registeredUserRepository;
            }
        }


        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
