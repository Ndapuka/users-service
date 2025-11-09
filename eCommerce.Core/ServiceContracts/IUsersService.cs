
using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;
/// <summary>
/// Contrat for user service that contains use cases for users 
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle a user login use case and return the authentication obj that contains status of login 
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?>Login(LoginRequest loginRequest);
    /// <summary>
    /// Methoud to handle a user registration use case and return the authentication obj that contains status of registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?>Register(RegisterRequest registerRequest);

    /// <summary>
    /// Returns USerDTO object based on the given UserID
    /// </summary>
    /// <param name="userID">UserID to search</param>
    /// <returns>USerDTO object based on the macthing USerID</returns>
    Task<UserDTO?> GetUserByUserID(Guid? userID);



}

