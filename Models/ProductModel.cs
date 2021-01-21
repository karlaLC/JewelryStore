using JewelryStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class ProductModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Category { get; set; }
		public int Price { get; set; }
		public ICollection<OrderProductModel> Orders { get; set; }
	}
}
