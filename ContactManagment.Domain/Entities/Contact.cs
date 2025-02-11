using ContactManagment.Domain.Common.Constants;
using ContactManagment.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactManagment.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; private set; } = new Guid();
        public string FirstName { get; private set; }
        public string SurName { get; private set; }
        public Date DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string IBAN { get; private set; }

        public Contact(string firstName, string surName, Date dateOfBirth, string address, string phoneNumber, string iban)
        {
            FirstName = ValidateFirstName(firstName);
            SurName = ValidateSurName(surName);
            DateOfBirth = dateOfBirth;
            Address = ValidateAddress(address);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            IBAN = ValidateIBAN(iban);
        }

        public void Update(string firstName, string surName, Date dateOfBirth, string address, string phoneNumber, string iban)
        {
            FirstName = ValidateFirstName(firstName);
            SurName = ValidateSurName(surName);
            DateOfBirth = dateOfBirth;
            Address = ValidateAddress(address);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            IBAN = ValidateIBAN(iban);
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
