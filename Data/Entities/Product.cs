﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data.Entities
{
    public class Product
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Category { get; set; }
		public int Price { get; set; }
		public ICollection<OrderProduct> Orders { get; set; }
	}
}
