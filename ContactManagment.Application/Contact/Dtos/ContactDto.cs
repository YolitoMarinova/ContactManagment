namespace ContactManagment.Application.Contact.Dtos
{
    public record ContactDto (Guid Id, string FirstName, string SurName, DateOnly DateOfBirth, string Address, string PhoneNumber, string Iban);
}
