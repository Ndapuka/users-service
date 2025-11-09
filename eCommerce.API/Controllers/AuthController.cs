using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] //api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    //Endpoint for user registration use case
    [HttpPost("register")] //api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        //check for invalid registerRequest
        if(registerRequest == null) 
        {
            return BadRequest("Invalid registration data");
        }
        //call the UsersService to handle the registration use case
        AuthenticationResponse? 
            authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest(authenticationResponse);
        }
        return Ok(authenticationResponse);
    }

    //Endpoint for user login use case
    [HttpPost("login")] //api/auth/login
    public async Task<IActionResult>Login(LoginRequest loginRequest)
    {
        //check for invalid loginRequest
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }
        //call the UsersService to handle the login use case
        AuthenticationResponse? authenticationResponse = await 
            _usersService.Login(loginRequest);
        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return Unauthorized(authenticationResponse);
        }

        return Ok(authenticationResponse);
    }
}

