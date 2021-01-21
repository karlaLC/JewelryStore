using JewelryStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data
{
    public class JewelryStoreRepository : IJewelryStoreRepository
    {
		private readonly JewelryStoreContext _ctx;

		public JewelryStoreRepository(JewelryStoreContext ctx)
		{
			_ctx = ctx;
		}

		public void Add<T>(T entity) where T : class
		{
			_ctx.Add(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			_ctx.Remove(entity);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _ctx.SaveChangesAsync() > 0; //at least one record would be changed if successful
		}

		public async Task<ICollection<Client>> GetAllClientsAsync()
		{
			IQueryable<Client> allClients = _ctx.Clients
				.Include(x => x.Orders);
			return await allClients.ToListAsync();
		}

		public void CreateClient(Client client)
		{
			Add(client);
		}

		public async Task<Client> GetClientById(int clientId)
		{
			IQueryable<Client> queryable = _ctx.Clients
				.Include(x => x.Orders)
				.ThenInclude(d => d.Products)
				.Where(x => x.Id == clientId);

			return await queryable.FirstOrDefaultAsync();
		}

		public void UpdateClient(Client client)
		{
			_ctx.Update(client);
		}

		public void DeleteClient(Client client)
		{
			Delete(client);
		}

		public async Task<ICollection<Order>> GetAllOrdersAsync()
		{
			IQueryable<Order> allOrders = _ctx.Orders.Include(x =>x.Products);
			return await allOrders.ToListAsync();
		}

	}
}
