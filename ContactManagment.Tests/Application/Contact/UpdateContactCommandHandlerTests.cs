using ContactManagment.Application.Contact.Commands.UpdateContactCommand;
using ContactManagment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContactManagment.Tests.Application.Contact
{
    public class UpdateContactCommandHandlerTests
    {
        private readonly ContactManagmentDbContext _dbContext;
        private readonly UpdateContactCommandHandler _handler;

        public UpdateContactCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ContactManagmentDbContext>()
           .UseInMemoryDatabase(Guid.NewGuid().ToString())
           .Options;
            _dbContext = new ContactManagmentDbContext(options);
            _handler = new UpdateContactCommandHandler(_dbContext);

            var contact = new Domain.Entities.Contact("John", "Doe", new DateOnly(1990, 1, 1), "123 Street", "1234567890", "IBAN1234567891011");
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Handle_ShouldUpdateContact()
        {
            var contact = await _dbContext.Contacts.FirstAsync();
            var command = new UpdateContactCommand
            (
                contact.Id,
                "Jane",
                null,
                null,
                "456 Avenue",
                "0987654321",
                null
            );

            await _handler.Handle(command, CancellationToken.None);
            var updatedContact = await _dbContext.Contacts.FindAsync(contact.Id);

            Assert.NotNull(updatedContact);
            Assert.Equal("Jane", updatedContact.FirstName);
            Assert.Equal(contact.SurName, updatedContact.SurName);
            Assert.Equal("456 Avenue", updatedContact.Address);
            Assert.Equal("0987654321", updatedContact.PhoneNumber);
            Assert.Equal(contact.Iban, updatedContact.Iban);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenContactDoesNotExist()
        {
            var command = new UpdateContactCommand
            (
                Guid.NewGuid(),
                "New Name",
                null,
                null,
                null,
                null,
                null
            );

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result);
        }
    }
}
