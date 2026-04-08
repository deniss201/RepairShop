using Microsoft.AspNetCore.Mvc;
using RepairShop.API.DTO;
using RepairShop.Core.Entities;
using RepairShop.Core.Interfaces;


namespace RepairShop.API.Controllers;

[ApiController]
[Route("api/User")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public ActionResult<User> RegisterUser([FromBody] RegisterRequest request)
    {
        return Ok(_userService.RegisterUser(request.Email, request.Password, request.FirstName, request.LastName, request.Phone));
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        return Ok(_userService.GetUserById(id));
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_userService.GetUsers());
    }
    
    [HttpPost("login")]
    public ActionResult<string> LoginUser([FromBody] LoginRequest request)
    {
        return Ok(_userService.LoginUser(request.Email, request.Password));
    }
    
}