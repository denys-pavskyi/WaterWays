using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validations
{
    public static class ModelsValidation
    {
        public static void OrderDetailModelValidation(OrderDetailModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("Product was null");
            }

            if (model.OrderId < 0)
            {
                throw new WaterWaysException("Wrong orderId");
            }

            if (model.ProductId < 0)
            {
                throw new WaterWaysException("Wrong productId");
            }

            if (model.Quantity < 0)
            {
                throw new WaterWaysException("Wrong quantity");
            }

            if (model.UnitPrice < 0)
            {
                throw new WaterWaysException("Wrong unitPrice");
            }

            


        }

        public static void OrderModelValidation(OrderModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("Order was null");
            }

            if (model.ContactPhone == null || model.ContactPhone == String.Empty)
            {
                throw new WaterWaysException("Wrong phone number");
            }
            if (model.Address == null || model.Address == String.Empty)
            {
                throw new WaterWaysException("Wrong address");
            }
            if (model.UserId < 0)
            {
                throw new WaterWaysException("Wrong userId");
            }

        }

        public static void ProductModelValidation(ProductModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("Product was null");
            }

            if (model.Title == null || model.Title == String.Empty)
            {
                throw new WaterWaysException("Wrong title");
            }

            if (model.WaterPointId < 0)
            {
                throw new WaterWaysException("Wrong waterPointId");
            }

            if (model.Price < 0)
            {
                throw new WaterWaysException("Wrong price");
            }

            if (model.QuantityAvailable < 0)
            {
                throw new WaterWaysException("Wrong quantity");
            }

        }

        public static void RegisteredUserModelValidation(RegisteredUserModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("Registered user was null");
            }

            if (model.FirstName == null || model.FirstName == String.Empty)
            {
                throw new WaterWaysException("Wrong firstName");
            }

            if (model.LastName == null || model.LastName == String.Empty)
            {
                throw new WaterWaysException("Wrong lastName");
            }

            if (model.UserName == null || model.UserName == String.Empty)
            {
                throw new WaterWaysException("Wrong userName");
            }

            if (model.Password == null || model.Password == String.Empty)
            {
                throw new WaterWaysException("Wrong password");
            }

            if (model.Email == null || model.Email == String.Empty)
            {
                throw new WaterWaysException("Wrong email");
            }

            if (model.Phone == null || model.Phone == String.Empty)
            {
                throw new WaterWaysException("Wrong phone number");
            }

            if (model.Address == null || model.Address == String.Empty)
            {
                throw new WaterWaysException("Wrong address");
            }

        }

        public static void ReviewModelValidation(ReviewModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("Review was null");
            }

            if (model.WaterPointId < 0)
            {
                throw new WaterWaysException("Wrong waterPointId");
            }

            if (model.UserId < 0)
            {
                throw new WaterWaysException("Wrong userId");
            }
            if (model.Rating < 0d || model.Rating > 5d)
            {
                throw new WaterWaysException("Wrong review rating");
            }

        }

        public static void ShoppingCartModelValidation(ShoppingCartModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("Shoppping cart item was null");
            }
            if (model.ProductId < 0)
            {
                throw new WaterWaysException("Wrong waterPointId");
            }
            if (model.Quantity < 0)
            {
                throw new WaterWaysException("Wrong quantity");
            }

            if (model.UnitPrice < 0)
            {
                throw new WaterWaysException("Wrong unit price");
            }

            if (model.TotalPrice < 0)
            {
                throw new WaterWaysException("Wrong total price");
            }

        }

        public static void WaterPointModelValidation(WaterPointModel model)
        {
            if (model == null)
            {
                throw new WaterWaysException("WaterPoint was null");
            }

            if (model.Title == null || model.Title == String.Empty)
            {
                throw new WaterWaysException("Wrong water point title");
            }

            if (model.PhoneNumber == null || model.PhoneNumber == String.Empty)
            {
                throw new WaterWaysException("Wrong water point phone number");
            }

            if (model.Address == null || model.Address == String.Empty)
            {
                throw new WaterWaysException("Wrong water point address");
            }

            if(model.Rating<0d || model.Rating > 5d)
            {
                throw new WaterWaysException("Wrong water point rating");
            }
        }

       
    }
}
