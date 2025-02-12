using ContactManagment.Application.Contact.Dtos;
using ContactManagment.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactManagment.Application.Contact.Queries.GetByIdContactQuery
{
    public class GetByIdContactQueryHandler(ContactManagmentDbContext dbContext) :
        IRequestHandler<GetByIdContactQuery, ContactDto?>
    {
        public async Task<ContactDto?> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Contacts
                .Where(c => c.Id == request.Id)
                .Select(c => new ContactDto(c.Id, c.FirstName, c.SurName, c.DateOfBirth, c.Address, c.PhoneNumber, c.Iban))
                .FirstOrDefaultAsync();
        }
    }
}
