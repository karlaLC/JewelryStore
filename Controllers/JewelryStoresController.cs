using AutoMapper;
using JewelryStore.Data;
using JewelryStore.Data.Entities;
using JewelryStore.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JewelryStore.Controllers
{
	[Microsoft.AspNetCore.Mvc.Route("api/[controller]")] 
    [ApiController] //for props binding (for requests)
	public class JewelryStoresController : ControllerBase //specific to APIs in .net core
    {
		private readonly IJewelryStoreRepository _repository;
		private readonly IMapper _mapper;
		private readonly LinkGenerator _linkGenerator;

		public JewelryStoresController(IJewelryStoreRepository repository, IMapper mapper, LinkGenerator linkGenerator)
		{
			_repository = repository;
			_mapper = mapper;
			_linkGenerator = linkGenerator;
		}

		//CLIENTS
        [HttpGet("clients")]
		public async Task<IActionResult> GetAllClients()
		{
			try
			{
				var results = await _repository.GetAllClientsAsync();
				ICollection<ClientModel> models = _mapper.Map<ICollection<ClientModel>>(results);

				return Ok(models);
			}
			catch (Exception exception)
			{
				return StatusCode(500, $"Database Failure: {exception}");
			}
			
		}

		[HttpGet("clients/by-client-id/{clientId:int}")]
		public async Task<ActionResult<ClientModel>> GetClientById(int clientId)
		{
			try
			{
				var result = await _repository.GetClientById(clientId);

				if (result == null)
				{
					return NotFound();
				}

				//if we specify ActionResult<T> in our signature and this returns the same type, it'll assume it's an Ok response.
				return _mapper.Map<ClientModel>(result);
			}
			catch (Exception exception)
			{
				return StatusCode(500, $"Database Failure: {exception}");
			}
		}

		[HttpPost("clients")]
		public async Task<ActionResult<ClientModel>> CreateClient(ClientModel model)
		{
			try
			{
				////get location to set as url in "created" response and retrieve newly created client 
				//var location = _linkGenerator.GetPathByAction("Get", "JewelryStores", new { clientId = model.Id });

				//if (string.IsNullOrWhiteSpace(location))
				//{
				//	return BadRequest($"Location for clientId: {model.Id} was not found");
				//}

				//Create new client
				var client = _mapper.Map<Client>(model);
				_repository.CreateClient(client);

				if (await _repository.SaveChangesAsync())
				{
					//return Created(location, _mapper.Map<ClientModel>(client));
					return Created($"/api/jewelrystores/clients/{client.Id}", _mapper.Map<ClientModel>(client));
				}

			}
			catch (Exception exception)
			{
				return StatusCode(500, $"Database Failure: {exception}");
			}

			return BadRequest();
		}

		[HttpPut("clients/{clientId:int}")]
		public async Task<ActionResult<ClientModel>> UpdateClient(int clientId, ClientModel model)
		{
			try
			{
				var clientToUpdate = await _repository.GetClientById(clientId);

				if (clientToUpdate == null)
				{
					return NotFound($"Could not find Client with Id: {clientId}");
				}

				_mapper.Map(model, clientToUpdate);

				if (await _repository.SaveChangesAsync())
				{
					return _mapper.Map<ClientModel>(clientToUpdate);
				}
			}
			catch (Exception exception)
			{
				return StatusCode(500, $"Database Failure: {exception}");
			}

			return BadRequest();
		}

		[HttpDelete("clients/{clientId:int}")]
		public async Task<IActionResult> DeleteClient(int clientId) //returning "IActionResult" as we'll only get back the result when deleting (no body, no id)
		{
			try
			{
				var clientToDelete = await _repository.GetClientById(clientId);

				if (clientToDelete == null)
				{
					return NotFound($"Could not find Client with Id: {clientId}");
				}

				_repository.DeleteClient(clientToDelete);

				if (await _repository.SaveChangesAsync())
				{
					return Ok();
				}

			}
			catch (Exception exception)
			{
				return StatusCode(500, $"Database Failure: {exception}");
			}

			return BadRequest($"Could not delete client with id: {clientId}");
		}

		//ORDERS
		[HttpGet("orders")]
		public async Task<IActionResult> GetAllOrders()
		{
			try
			{
				var results = await _repository.GetAllOrdersAsync();
				ICollection<OrderModel> models = _mapper.Map<ICollection<OrderModel>>(results);

				return Ok(models);
			}
			catch (Exception exception)
			{
				return StatusCode(500, $"Database Failure: {exception}");
			}

		}
	}
}
