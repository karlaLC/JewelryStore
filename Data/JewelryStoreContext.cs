using JewelryStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data
{
	//To query db
	public class JewelryStoreContext : DbContext
	{
		private readonly IConfiguration _config;

		//DbContextOptions w/our Context, to pass the options we're setting @ Startup, so it knows which db connection to use
		public JewelryStoreContext(DbContextOptions<JewelryStoreContext> options, IConfiguration config) : base(options)
		{
			_config = config;
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }

		//To specify how the mapping between entities and db is going to happen
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Address>()
				.HasData(new Address 
				{ 
					Id = 1, 
					Number = 123, 
					StreetName = "Fake St", 
					State = "CA", 
					ZipCode = 90210 
				});

			modelBuilder.Entity<Client>()
				//To seed "default" data w/each migration (affects runtime performance, so pref for very simple items/data) 
				.HasData(new Client
				{
					Id = 1,
					FirstName = "Marina",
					LastName = "Lopez",
					AddressId = 1,
					UserName = "marina.lopez"
				});

			modelBuilder.Entity<Order>()
				.HasData(new Order
				{
					Id = 1,
					ClientId = 1
				},
				new Order
				{
					Id = 2,
					ClientId = 1
				},
				new Order
				{
					Id = 3,
					ClientId = 1
				});

			modelBuilder.Entity<Product>()
				.HasData(new Product
				{
					Id = 1,
					Name = "14K Gold Necklace",
					Type = "Gold",
					Category = "Short necklaces",
					Price = 10500
				},
				new Product
				{
					Id = 2,
					Name = "18K Gold Earrings",
					Type = "Gold",
					Category = "Stud earrings",
					Price = 5500
				},
				new Product
				{
					Id = 3,
					Name = "24K Gold Ring",
					Type = "Gold",
					Category = "Stackable rings",
					Price = 6500
				},
				new Product
				{
					Id = 4,
					Name = "14K Gold Necklace",
					Type = "Gold",
					Category = "Short necklaces",
					Price = 3500
				},
				new Product
				{
					Id = 5,
					Name = ".925 Silver Necklace",
					Type = "Silver",
					Category = "Long necklaces",
					Price = 5000
				});

			modelBuilder.Entity<OrderProduct>()
				.HasData(new OrderProduct
				{
					Id = 1,
					OrderId = 1,
					ProductId = 1
				},
				new OrderProduct
				{
					Id = 2,
					OrderId = 1,
					ProductId = 2
				},
				new OrderProduct
				{
					Id = 3,
					OrderId = 1,
					ProductId = 3
				});
		}
	}
}
