using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class AddressModel
    {
		public int Id { get; set; }
		public int Number { get; set; }
		public string StreetName { get; set; }
		public string State { get; set; }
		public int ZipCode { get; set; }
	}
}
