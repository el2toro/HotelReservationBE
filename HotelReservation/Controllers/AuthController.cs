using HotelReservation.DTOs;
using HotelReservation.Repository;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservation.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class AuthController : Controller
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;

    public AuthController(IAuthRepository authRepository, IJwtService jwtService)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(UserDto user)
    {
        var existingUser = _authRepository.Login(user);

        if (existingUser != null && !string.IsNullOrEmpty(existingUser.Username))
        {
            var token = _jwtService.GenerateJwtToken(existingUser.Username);

            return Ok(new { token });
        }

        return Unauthorized();
    }
}
