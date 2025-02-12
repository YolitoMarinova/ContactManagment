using ContactManagment.Application.Contact.Dtos;
using ContactManagment.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactManagment.Application.Contact.Queries.GetAllContactQuery
{
    public class GetAllContactQueryHandler(ContactManagmentDbContext dbContext) :
        IRequestHandler<GetAllContactQuery, List<ContactDto>>
    {
        public async Task<List<ContactDto>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Contacts
                .Select(c => new ContactDto(c.Id, c.FirstName, c.SurName, c.DateOfBirth, c.Address, c.PhoneNumber, c.Iban))
                .ToListAsync();
        }
    }
}
