using JewelryStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class ClientModel
    {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int AddressId { get; set; }
		public AddressModel Address { get; set; }
		public string UserName { get; set; }
		public ICollection<OrderModel> Orders { get; set; }
	}
}
