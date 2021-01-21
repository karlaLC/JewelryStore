using JewelryStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class OrderModel
    {
		public int Id { get; set; }
		public int ClientId { get; set; }
		public ICollection<OrderProductModel> Products { get; set; }
	}
}
