//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Omega.Core.DTOs;
//using Omega.Domain.Commands;
//using Omega.Domain.Queries;
//using Omega.Domain.Queries.ServiceItems;
//using Omega.Domain.ValueObjects;


//namespace Omega.Presentation.Server.Controllers.APIs
//{
//	[Route("api/[controller]")]
//	[ApiController]
//	public class ServiceItemController : ControllerBase
//	{
//		private readonly IMediator _mediator;
//		private readonly ILogger<ServiceItemController> _logger;

//		public ServiceItemController(IMediator mediator, ILogger<ServiceItemController> logger)
//		{
//			_mediator = mediator;
//			_logger = logger;
//		}

//		[HttpGet]
//		[ActionName("GetAllServiceItems")]
//		public async Task<IActionResult> GetAllServiceItems()
//		{
//			try
//			{
//				var query = new GetAllServiceItemsQuery();
//				var serviceItems = await _mediator.Send(query);
//				return Ok(serviceItems);
//			}
//			catch (Exception ex)
//			{
//				_logger.LogError(ex, "An error occurred while retrieving serviceItems.");
//				return StatusCode(500, "An error occurred while retrieving serviceItems.");
//			}
//		}

//		[HttpGet("{customerId}")]
//		[ActionName("GetServiceItemById")]
//		public async Task<IActionResult> GetServiceItemById(int customerId)
//		{
//			try
//			{
//				var query = new GetServiceItemByIdQuery { ServiceItemId = customerId };
//				var customer = await _mediator.Send(query);

//				if (customer == null)
//				{
//					return NotFound($"ServiceItem with ID {customerId} not found.");
//				}

//				return Ok(customer);
//			}
//			catch (Exception ex)
//			{
//				_logger.LogError(ex, "An error occurred while retrieving the customer.");
//				return StatusCode(500, "An error occurred while retrieving the customer.");
//			}
//		}

//		[HttpPost]
//		[ActionName("CreateServiceItem")]
//		public async Task<IActionResult> CreateServiceItem([FromBody] ServiceItemWriteDTO customer)
//		{
//			try
//			{
//				// Validate input data
//				if (!ModelState.IsValid)
//				{
//					var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
//					return BadRequest(errors);
//				}

//				var command = new CreateServiceItemCommand(customer.Firstname, customer.Lastname, customer.DateOfBirth, customer.PhoneNumber, customer.Email, customer.BankAccountNumber);
//				var createdServiceItem = await _mediator.Send(command);

//				return CreatedAtAction(nameof(GetServiceItemById), new { customerId = createdServiceItem.Id },
//					createdServiceItem);
//			}
//			catch (Exception ex)
//			{
//				_logger.LogError(ex, "An error occurred while creating the customer.");
//				return StatusCode(500, "An error occurred while creating the customer.");
//			}
//		}
//		[HttpPut("{customerId}")]
//		[ActionName("UpdateServiceItem")]
//		public async Task<IActionResult> UpdateServiceItem(int customerId, [FromBody] ServiceItemWriteDTO customer)
//		{
//			try
//			{
//				var bankAccountNumber = new BankAccountNumber(customer.BankAccountNumber);

//				var command = new UpdateServiceItemCommand(customerId, customer.Firstname, customer.Lastname, customer.DateOfBirth, customer.PhoneNumber, customer.Email, bankAccountNumber);
//				await _mediator.Send(command);

//				return NoContent();
//			}
//			catch (ArgumentException ex)
//			{
//				return NotFound(ex.Message);
//			}
//			catch (Exception ex)
//			{
//				_logger.LogError(ex, "An error occurred while updating the customer.");
//				return StatusCode(500, "An error occurred while updating the customer.");
//			}
//		}

//		[HttpDelete("{customerId}")]
//		[ActionName("DeleteServiceItem")]
//		public async Task<IActionResult> DeleteServiceItem(int customerId)
//		{
//			try
//			{
//				var command = new DeleteServiceItemCommand(customerId);
//				await _mediator.Send(command);

//				return NoContent();
//			}
//			catch (ArgumentException ex)
//			{
//				return NotFound(ex.Message);
//			}
//			catch (Exception ex)
//			{
//				_logger.LogError(ex, "An error occurred while deleting the customer.");
//				return StatusCode(500, "An error occurred while deleting the customer.");
//			}
//		}
//	}
//}