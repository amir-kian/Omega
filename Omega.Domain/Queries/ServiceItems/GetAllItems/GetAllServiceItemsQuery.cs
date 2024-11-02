using MediatR;
using Omega.Core.DTOs.ServiceItems.GetAllItems;

namespace Omega.Domain.Queries.ServiceItems.GetAllItems;



public record GetAllServiceItemsQuery() : IRequest<ServiceItemReadDTO[]>;

