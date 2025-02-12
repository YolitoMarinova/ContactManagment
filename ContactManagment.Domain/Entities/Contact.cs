using ContactManagment.Domain.Common.Constants;
using ContactManagment.Domain.Common.Errors;

namespace ContactManagment.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; private set; } = new Guid();
        public string FirstName { get; private set; }
        public string SurName { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Iban { get; private set; }

        public Contact(string firstName, string surName, DateOnly dateOfBirth, string address, string phoneNumber, string iban)
        {
            FirstName = ValidateFirstName(firstName);
            SurName = ValidateSurName(surName);
            DateOfBirth = dateOfBirth;
            Address = ValidateAddress(address);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            Iban = ValidateIBAN(iban);
        }

        public void Update(string? firstName, string? surName, DateOnly? dateOfBirth, string? address, string? phoneNumber, string? iban)
        {
            FirstName = firstName != null ? ValidateFirstName(firstName) : FirstName;
            SurName = surName != null ? ValidateSurName(surName) : SurName;
            DateOfBirth = dateOfBirth ?? DateOfBirth;
            Address = address != null ? ValidateAddress(address) : Address;
            PhoneNumber = phoneNumber != null ? ValidatePhoneNumber(phoneNumber) : PhoneNumber;
            Iban = iban != null ? ValidateIBAN(iban) : Iban;
        }

        private string ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > ContactConstants.FirstNameMaxLength)
            {
                throw new ArgumentException(string.Format(ContactErrorMessages.InvalidFirstName, ContactConstants.FirstNameMaxLength));
            }

            return firstName;
        }

        private string ValidateSurName(string surName)
        {
            if (string.IsNullOrWhiteSpace(surName) || surName.Length > ContactConstants.SurNameMaxLength)
            {
                throw new ArgumentException(string.Format(ContactErrorMessages.InvalidSurName, ContactConstants.SurNameMaxLength));
            }
            return surName;
        }

        private string ValidateAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || address.Length > ContactConstants.AddressMaxLength)
            {
                throw new ArgumentException(string.Format(ContactErrorMessages.InvalidAddress, ContactConstants.AddressMaxLength));
            }
            return address;
        }

        private string ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length > ContactConstants.PhoneNumberMaxLength)
            {
                throw new ArgumentException(string.Format(ContactErrorMessages.InvalidPhoneNumber, ContactConstants.PhoneNumberMaxLength));
            }
            return phoneNumber;
        }

        private string ValidateIBAN(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban) || iban.Length < ContactConstants.IBANMinLength || iban.Length > ContactConstants.IBANMaxLength)
            {
                throw new ArgumentException(string.Format(ContactErrorMessages.InvalidIBAN, ContactConstants.IBANMinLength, ContactConstants.IBANMaxLength));
            }
            return iban;
        }
    }
}
