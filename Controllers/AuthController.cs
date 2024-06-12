using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using System.Text; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using System.Security.Claims;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(UserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserModel user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await _userService.CreateUser(user);
        return Ok(new { message = "Usuário registrado com sucesso" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserModel user)
    {
        var dbUser = await _userService.GetUserByUsername(user.Username);
        if (dbUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password))
        {
            return Unauthorized();
        }

        var token = GenerateJwtToken(dbUser);
        return Ok(new { token });
    }

    private string GenerateJwtToken(UserModel user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
