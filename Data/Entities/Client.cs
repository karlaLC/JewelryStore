using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data.Entities
{
	public class Client
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[ForeignKey("Address")]
		public int AddressId { get; set; }
		public Address Address { get; set; }
		public string UserName { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
