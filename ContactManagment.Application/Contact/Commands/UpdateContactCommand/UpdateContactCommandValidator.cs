using ContactManagment.Domain.Common.Constants;
using ContactManagment.Domain.Common.Errors;
using FluentValidation;

namespace ContactManagment.Application.Contact.Commands.UpdateContactCommand
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().NotNull().MaximumLength(ContactConstants.FirstNameMaxLength)
                .When(c => c.FirstName != null)
                .WithMessage(string.Format(ContactErrorMessages.InvalidFirstName, ContactConstants.FirstNameMaxLength));
            RuleFor(c => c.SurName)
                .NotEmpty().NotNull().MaximumLength(ContactConstants.SurNameMaxLength)
                .When(c => c.SurName != null)
                .WithMessage(string.Format(ContactErrorMessages.InvalidSurName, ContactConstants.SurNameMaxLength));
            RuleFor(c => c.Address)
                .NotEmpty().NotNull().MaximumLength(ContactConstants.AddressMaxLength)
                .When(c => c.Address != null)
                .WithMessage(string.Format(ContactErrorMessages.InvalidAddress, ContactConstants.AddressMaxLength));
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().NotNull().MaximumLength(ContactConstants.PhoneNumberMaxLength)
                .When(c => c.PhoneNumber != null)
                .WithMessage(string.Format(ContactErrorMessages.InvalidPhoneNumber, ContactConstants.PhoneNumberMaxLength));
            RuleFor(c => c.Iban)
                .NotEmpty().NotNull().MinimumLength(ContactConstants.IBANMinLength).MaximumLength(ContactConstants.IBANMaxLength)
                .When(c => c.Iban != null)
                .WithMessage(string.Format(ContactErrorMessages.InvalidIBAN, ContactConstants.IBANMinLength, ContactConstants.IBANMaxLength));
        }
    }
}
