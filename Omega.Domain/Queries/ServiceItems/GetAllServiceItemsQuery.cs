using MediatR;
using Omega.Core.DTOs.ServiceItems;

namespace Omega.Domain.Queries.ServiceItems;



public record GetAllServiceItemsQuery() : IRequest<ServiceItemReadDTO[]>;

