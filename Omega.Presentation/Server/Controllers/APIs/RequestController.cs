using MediatR;
using Microsoft.AspNetCore.Mvc;
using Omega.Core.DTOs.Request;
using Omega.Domain.Commands.Request;
using Omega.Domain.Queries.Request;
using System;


namespace Omega.Presentation.Server.Controllers.APIs
{
	[Route("api/[controller]")]
	[ApiController]
	public class RequestController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<RequestController> _logger;

		public RequestController(IMediator mediator, ILogger<RequestController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		[ActionName("GetAllRequests")]
		public async Task<IActionResult> GetAllRequests()
		{
			try
			{
				var query = new GetAllRequestsQuery();
				var Requests = await _mediator.Send(query);
				return Ok(Requests);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while retrieving Requests.");
				return StatusCode(500, "An error occurred while retrieving Requests.");
			}
		}

		[HttpGet("{RequestId}")]
		[ActionName("GetRequestById")]
		public async Task<IActionResult> GetRequestById(int RequestId)
		{
			try
			{
				var query = new GetRequestByIdQuery { RequestId = RequestId };
				var Request = await _mediator.Send(query);

				if (Request == null)
				{
					return NotFound($"Request with ID {RequestId} not found.");
				}

				return Ok(Request);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while retrieving the Request.");
				return StatusCode(500, "An error occurred while retrieving the Request.");
			}
		}



		[HttpPost]
		[ActionName("CreateRequest")]
		public async Task<IActionResult> CreateRequest([FromBody] RequestWriteDTO request)
		{
			try
			{
				// Validate input data
				if (!ModelState.IsValid)
				{
					var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
					return BadRequest(errors);
				}

				var command = new CreateRequestCommand(request.Title, request.RequestType, request.Fund);
				var createdRequest = await _mediator.Send(command);

				double insurancePremium = createdRequest.GetInsurancePremium(createdRequest.RequestType, createdRequest.Fund);

				// Return the insurance premium as a response
				return Ok(insurancePremium);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating the request.");
				return StatusCode(500, "An error occurred while creating the request.");
			}
		}

		[HttpPut("{RequestId}")]
		[ActionName("UpdateRequest")]
		public async Task<IActionResult> UpdateRequest(int RequestId, [FromBody] RequestWriteDTO Request)
		{
			try
			{

				var command = new UpdateRequestCommand(RequestId, Request.Title, Request.RequestType, Request.Fund);
				await _mediator.Send(command);

				return NoContent();
			}
			catch (ArgumentException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating the Request.");
				return StatusCode(500, "An error occurred while updating the Request.");
			}
		}

		[HttpDelete("{RequestId}")]
		[ActionName("DeleteRequest")]
		public async Task<IActionResult> DeleteRequest(int RequestId)
		{
			try
			{
				var command = new DeleteRequestCommand(RequestId);
				await _mediator.Send(command);

				return NoContent();
			}
			catch (ArgumentException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while deleting the Request.");
				return StatusCode(500, "An error occurred while deleting the Request.");
			}
		}
	}
}