using API.Domain.Model.EmployeeAggregate;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Application.Services
{
    public class TokenService
    {
        public static object GenerateToken(Employee employee)
        {
            byte[] key = Encoding.ASCII.GetBytes(Key.Secret);

            SecurityTokenDescriptor TokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim("employeeId", employee.id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = TokenHandler.CreateToken(TokenConfig);

            string tokenstring = TokenHandler.WriteToken(token);

            return new
            {
                token = tokenstring
            };
        }
    }
}
