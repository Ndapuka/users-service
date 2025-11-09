
using eCommerce.Core.DTO;

namespace eCommerce.Core.Entities;
/// <summary>
/// Define type ApplicationUser class which acts as entity model class to store user details in data store
/// </summary>
public class ApplicationUser
{
    public Guid UserID { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public GenderOptions Gender { get; set; }

}

