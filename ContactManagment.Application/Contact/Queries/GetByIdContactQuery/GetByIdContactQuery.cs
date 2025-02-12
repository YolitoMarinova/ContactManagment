using ContactManagment.Application.Contact.Dtos;
using MediatR;

namespace ContactManagment.Application.Contact.Queries.GetByIdContactQuery
{
    public record GetByIdContactQuery(Guid Id) : IRequest<ContactDto>;
}
