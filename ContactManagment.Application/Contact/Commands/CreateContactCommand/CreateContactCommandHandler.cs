using ContactManagment.Infrastructure.Persistence;
using MediatR;

namespace ContactManagment.Application.Contact.Commands.CreateContactCommand
{
    public class CreateContactCommandHandler(ContactManagmentDbContext dbContext) :
        IRequestHandler<CreateContactCommand, Guid>
    {
        public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
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
            return contact.Id;
        }
    }
}
