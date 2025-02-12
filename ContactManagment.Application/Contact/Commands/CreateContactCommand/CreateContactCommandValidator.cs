using ContactManagment.Domain.Common.Constants;
using ContactManagment.Domain.Common.Errors;
using FluentValidation;

namespace ContactManagment.Application.Contact.Commands.CreateContactCommand
{
    public class CreateContactCommandValidator: AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().NotNull().MaximumLength(ContactConstants.FirstNameMaxLength)
                .WithMessage(string.Format(ContactErrorMessages.InvalidFirstName, ContactConstants.FirstNameMaxLength));
            RuleFor(c => c.SurName).NotEmpty().NotNull().MaximumLength(ContactConstants.SurNameMaxLength)
                .WithMessage(string.Format(ContactErrorMessages.InvalidSurName, ContactConstants.SurNameMaxLength));
            RuleFor(c => c.Address).NotEmpty().NotNull().MaximumLength(ContactConstants.AddressMaxLength)
                .WithMessage(string.Format(ContactErrorMessages.InvalidAddress, ContactConstants.AddressMaxLength));
            RuleFor(c => c.PhoneNumber).NotEmpty().NotNull().MaximumLength(ContactConstants.PhoneNumberMaxLength)
                .WithMessage(string.Format(ContactErrorMessages.InvalidPhoneNumber, ContactConstants.PhoneNumberMaxLength));
            RuleFor(c => c.Iban).NotEmpty().NotNull().MinimumLength(ContactConstants.IBANMinLength).MaximumLength(ContactConstants.IBANMaxLength)
                .WithMessage(string.Format(ContactErrorMessages.InvalidIBAN, ContactConstants.IBANMinLength, ContactConstants.IBANMaxLength));
        }
    }
}
