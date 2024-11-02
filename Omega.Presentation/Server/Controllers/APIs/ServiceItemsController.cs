using MediatR;
using Microsoft.AspNetCore.Mvc;
using Omega.Domain.Queries.ServiceItems.GetAllItems;
using Omega.Domain.Queries.ServiceItems.GetItem;


namespace Omega.Presentation.Server.Controllers.APIs;

[Route("api/[controller]")]
[ApiController]
public class ServiceItemsController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly ILogger<ServiceItemsController> _logger;
	private readonly IConfiguration _configuration;

	public ServiceItemsController(
	IMediator mediator,
	ILogger<ServiceItemsController> logger,
	IConfiguration configuration)
	{
		_mediator = mediator;
		_logger = logger;
		_configuration = configuration;
	}

	[HttpGet("GetAll")]
	public async Task<IActionResult> GetAllServiceItems()
	{
		try
		{
			var query = new GetAllServiceItemsQuery();
			var items = await _mediator.Send(query);
			return Ok(items);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while retrieving customers.");
			return StatusCode(500, "An error occurred while retrieving customers.");
		}
	}

	[HttpGet("Get/{serviceItem}")]
	public async Task<IActionResult> GetServiceItem(int serviceItem)
	{
		try
		{
			var query = new GetServiceItemQuery(serviceItem);
			var item = await _mediator.Send(query);
			return Ok(item);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while retrieving customers.");
			return StatusCode(500, "An error occurred while retrieving customers.");
		}
	}
}
