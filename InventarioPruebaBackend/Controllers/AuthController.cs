using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Credenciales fijas en memoria
        if (request.Username == "admin" && request.Password == "1234")
        {
            var token = _jwtService.GenerateToken(request.Username);
            return Ok(new { token });
        }

        return Unauthorized("Credenciales incorrectas");
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
