using System.Collections.Generic;

namespace ContactManagment.Domain.Common.Errors
{
    public static class ContactErrorMessages
    {
        public const string InvalidFirstName = "First cannot be empty or longer than {0} characters.";
        public const string InvalidSurName = "Sur cannot be empty or longer than {0} characters.";
        public const string InvalidAddress = "Address cannot be empty or longer than {0} characters.";
        public const string InvalidPhoneNumber = "Phone number cannot be empty or longer than {0} characters.";
        public const string InvalidIBAN = "IBAN cannot be empty and should be between {0} and {1} characters.";
    }
}
