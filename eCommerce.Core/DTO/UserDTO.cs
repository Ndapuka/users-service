namespace eCommerce.Core.DTO;

public record UserDTO(Guid UserID, string? Email, string? PersonName, string Gender)
{
    public UserDTO() : this(Guid.Empty, string.Empty, string.Empty, string.Empty)
    {
        UserID = UserID;
        Email = Email;
        PersonName = PersonName;
        Gender = Gender;
            
    }
}
