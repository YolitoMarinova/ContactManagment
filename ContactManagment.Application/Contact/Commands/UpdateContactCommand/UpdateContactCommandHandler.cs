using ContactManagment.Infrastructure.Persistence;
using MediatR;

namespace ContactManagment.Application.Contact.Commands.UpdateContactCommand
{
    public class UpdateContactCommandHandler(ContactManagmentDbContext dbContext) :
        IRequestHandler<UpdateContactCommand, bool>
    {
        public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await dbContext.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                return false;
            }
            contact.Update(
                request.FirstName, 
                request.SurName, 
                request.DateOfBirth, 
                request.Address, 
                request.PhoneNumber, 
                request.Iban
                );

            //We can use change tracker so to avoid unnecessary DB calls
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
