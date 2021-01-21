using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data.Entities
{
    public class Order
    {
		public int Id { get; set; }
		[ForeignKey("Client")]
		public int ClientId { get; set; }
		public Client Client { get; set; }
		public ICollection<OrderProduct> Products { get; set; }
	}
}
