using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Order, OrderModel>()
                .ForMember(om => om.OrderDetailIds, o => o.MapFrom(x => x.OrderDetails.Select(x => x.Id)));

            CreateMap<OrderModel, Order>()
                .ForMember(o => o.User, om => om.UseDestinationValue());


            CreateMap<OrderDetail, OrderDetailModel>();

            CreateMap<OrderDetailModel, OrderDetail>()
                .ForMember(o => o.Order, om => om.UseDestinationValue())
                .ForMember(o => o.Product, om => om.UseDestinationValue());

            CreateMap<Product, ProductModel>();

            CreateMap<ProductModel, Product>()
                .ForMember(o => o.WaterPoint, om => om.UseDestinationValue());

            CreateMap<RegisteredUser, RegisteredUserModel>()
                .ForMember(rum => rum.OrderIds, ruser => ruser.MapFrom(x => x.Orders.Select(x => x.Id)))
                .ForMember(rum => rum.ShoppingCartItemIds, ruser => ruser.MapFrom(x => x.ShoppingCartItems.Select(x=>x.Id)))
                .ReverseMap();

            CreateMap<Review, ReviewModel>();

            CreateMap<ReviewModel, Review>()
                .ForMember(r => r.User, rm => rm.UseDestinationValue())
                .ForMember(r => r.WaterPoint, rm => rm.UseDestinationValue());

            CreateMap<ShoppingCart, ShoppingCartModel>();

            CreateMap<ShoppingCartModel, ShoppingCart>()
                .ForMember(sc => sc.Product, scm => scm.UseDestinationValue());
                

            CreateMap<WaterPoint, WaterPointModel>()
                .ForMember(wpm => wpm.ProductIds, wp => wp.MapFrom(x => x.Products.Select(x => x.Id)))
                .ForMember(wpm => wpm.ReviewIds, wp => wp.MapFrom(x => x.Reviews.Select(x => x.Id)));

            CreateMap<WaterPointModel, WaterPoint>()
                .ForMember(wp => wp.WaterPointRepresentative, wpm => wpm.UseDestinationValue());
        }
    }
}
