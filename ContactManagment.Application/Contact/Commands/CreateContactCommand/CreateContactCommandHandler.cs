using ContactManagment.Application.Contact.Dtos;
using ContactManagment.Infrastructure.Persistence;
using MediatR;

namespace ContactManagment.Application.Contact.Commands.CreateContactCommand
{
    public class CreateContactCommandHandler(ContactManagmentDbContext dbContext) :
        IRequestHandler<CreateContactCommand, ContactDto>
    {
        public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Domain.Entities.Contact(
                request.FirstName,
                request.SurName,
                request.DateOfBirth,
                request.Address,
                request.PhoneNumber,
                request.Iban
            );

            await dbContext.Contacts.AddAsync(contact, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new ContactDto(
                contact.Id,
                contact.FirstName,
                contact.SurName,
                contact.DateOfBirth,
                contact.Address,
                contact.PhoneNumber,
                contact.Iban
            );
        }
    }
}
