using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omega.Core.DTOs;
using Omega.Domain.Commands;
using Omega.Domain.Queries;
using Omega.Domain.Queries.ServiceItems;
using Omega.Domain.ValueObjects;


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

	[HttpGet]
	[ActionName("GetAllServiceItemss")]
	public async Task<IActionResult> GetAllServiceItemss()
	{
		try
		{
			var query = new GetAllServiceItemsQuery();
			var customers = await _mediator.Send(query);
			return Ok(customers);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while retrieving customers.");
			return StatusCode(500, "An error occurred while retrieving customers.");
		}
	}


}