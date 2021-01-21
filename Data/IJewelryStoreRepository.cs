using JewelryStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Data
{
	public interface IJewelryStoreRepository
	{
		void Add<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		Task<bool> SaveChangesAsync();

		//Clients
		Task<ICollection<Client>> GetAllClientsAsync(); 
		void CreateClient(Client client); 
		Task<Client> GetClientById(int clientId); 
		void UpdateClient(Client client); 
		void DeleteClient(Client client);

		//Orders
		Task<ICollection<Order>> GetAllOrdersAsync();
	}
}