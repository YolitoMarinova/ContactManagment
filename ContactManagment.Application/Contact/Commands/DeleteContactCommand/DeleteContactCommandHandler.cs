using ContactManagment.Infrastructure.Persistence;
using MediatR;

namespace ContactManagment.Application.Contact.Commands.DeleteContactCommand
{
    public class DeleteContactCommandHandler(ContactManagmentDbContext dbContext) :
        IRequestHandler<DeleteContactCommand>
    {
        public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await dbContext.Contacts.FindAsync(request.Id);
            if (contact == null)
            {
                return;
            }
            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync();
        }
    }
}
