using MediatR;
using Omega.Core.DTOs.ServiceItems.GetItem;

namespace Omega.Domain.Queries.ServiceItems.GetItem;


public record GetServiceItemQuery(int ServiceReqiestId) : IRequest<GetServiceItemReadDTO[]>;

