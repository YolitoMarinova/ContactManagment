using ContactManagment.Domain.Common.Constants;
using ContactManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManagment.Infrastructure.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName)
                .HasMaxLength(ContactConstants.FirstNameMaxLength)
                .IsRequired();
            builder.Property(c => c.SurName)
                .HasMaxLength(ContactConstants.SurNameMaxLength)
                .IsRequired();
            builder.Property(c => c.DateOfBirth)
                .IsRequired();
            builder.Property(c => c.Address)
                .HasMaxLength(ContactConstants.AddressMaxLength)
                .IsRequired();
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(ContactConstants.PhoneNumberMaxLength)
                .IsRequired();
            builder.Property(c => c.Iban)
                .HasMaxLength(ContactConstants.IBANMaxLength)
                .IsRequired();
        }
    }
}
