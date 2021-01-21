using AutoMapper;
using JewelryStore.Data.Entities;
using JewelryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data
{
	public class JewelryStoreProfile : Profile
    {
		public JewelryStoreProfile()
		{
			CreateMap<Client, ClientModel>().ReverseMap();
			CreateMap<Order, OrderModel>();
			CreateMap<Product, ProductModel>();
			CreateMap<Address, AddressModel>();
			CreateMap<OrderProduct, OrderProductModel>();
		}
    }
}
