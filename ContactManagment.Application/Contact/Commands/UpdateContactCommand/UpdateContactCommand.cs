using MediatR;

namespace ContactManagment.Application.Contact.Commands.UpdateContactCommand
{
    public record UpdateContactCommand(Guid Id, string? FirstName, string? SurName, DateOnly? DateOfBirth, string? Address, string? PhoneNumber, string? Iban): IRequest;
}
