using ContactManagment.Application.Contact.Commands.CreateContactCommand;
using ContactManagment.Infrastructure.Persistence;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace ContactManagment.Tests.Application.Contact
{
    public class CreateContactCommandHandlerTests
    {
        private readonly ContactManagmentDbContext _dbContext;
        private readonly CreateContactCommandHandler _handler;

        public CreateContactCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ContactManagmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _dbContext = new ContactManagmentDbContext(options);
            _handler = new CreateContactCommandHandler(_dbContext);
        }

        [Fact]
        public async Task Handle_ShouldCreateContact()
        {
            var command = new CreateContactCommand(
                FirstName: "John",
                SurName: "Doe",
                DateOfBirth: new DateOnly(1990, 1, 1),
                Address: "123 Street",
                PhoneNumber: "1234567890",
                Iban: "IBAN1234567891011"
            );

            var contactId = await _handler.Handle(command, CancellationToken.None);
            var contact = await _dbContext.Contacts.FindAsync(contactId);

            Assert.NotNull(contact);
            Assert.Equal(command.FirstName, contact.FirstName);
        }
    }
}

