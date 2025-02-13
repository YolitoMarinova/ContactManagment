using ContactManagment.Application.Contact.Dtos;
using MediatR;

namespace ContactManagment.Application.Contact.Commands.CreateContactCommand
{
    public record CreateContactCommand(string FirstName, string SurName, DateOnly DateOfBirth, string Address, string PhoneNumber, string Iban) : IRequest<ContactDto>;
}
