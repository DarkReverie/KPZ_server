using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using DS_Lab_3.Interfaces;
using DS_Lab_3.Models;
using Microsoft.IdentityModel.Tokens;

namespace DS_Lab_3.Services;

public class AuthenticationService:IAuthenticationService
{
    private readonly GymDsCopyContext _context;

    public AuthenticationService(GymDsCopyContext context)
    {
        this._context = context;
    }
    
    public string AuthenticateUser(string username, string password)
    {
        var employee = _context.Employees.SingleOrDefault(e => e.EmployeeEmail == username && e.Surname == password);

        if (employee != null)
        {
            return GenerateJsonWebToken(employee);
        }

        var membership = _context.Memberships.SingleOrDefault(m => m.MemberEmail == username && m.Surname == password);

        if (membership != null)
        {
            return GenerateJsonWebToken(membership);
        }

        throw new AuthenticationException("Invalid username or password.");
    }

    private string GenerateJsonWebToken(Employee employee)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, employee.EmployeeEmail),
            new Claim(ClaimTypes.Role, "employee") 
        };

        var jwt = new JwtSecurityToken(
            issuer: AuthenticationOptions.ISSUER,
            audience: AuthenticationOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
            signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private string GenerateJsonWebToken(Membership membership)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, $"{membership.Name} {membership.Surname}"),
            new Claim(ClaimTypes.Role, "membership") 
        };

        var jwt = new JwtSecurityToken(
            issuer: AuthenticationOptions.ISSUER,
            audience: AuthenticationOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
            signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(), 
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}