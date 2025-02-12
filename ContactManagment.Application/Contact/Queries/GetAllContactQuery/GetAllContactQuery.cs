using ContactManagment.Application.Contact.Dtos;
using MediatR;

namespace ContactManagment.Application.Contact.Queries.GetAllContactQuery
{
    public record GetAllContactQuery : IRequest<List<ContactDto>>
    {

    }
}
