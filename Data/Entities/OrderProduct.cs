﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data.Entities
{
    public class OrderProduct
    {
		public int Id { get; set; }
		[ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }        
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
