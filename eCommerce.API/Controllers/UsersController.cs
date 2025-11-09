using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    //Endpoint to get user by UserID
    //GET: api/users/{userID}
    [HttpGet("{userID:guid}")] //[HttpGet("{userID:guid}")] only type guid is allowed
    public async Task<IActionResult> GetUserByUserID(Guid? userID)
    {
        //await Task.Delay(10000); //Simulate some delay for demonstration purposes
        //throw new NotImplementedException("This method is not implemented yet.");
        
        if (userID == null || userID == Guid.Empty)
        {
            return BadRequest("Invalid User ID");
        }
        //call the UsersService to get the user by UserID
        UserDTO? response = await _usersService.GetUserByUserID(userID);
        if (response == null)
        {
            return NotFound($"User with ID {userID} not found");
        }
        return Ok(response);
    }
}
