using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ws_Agenda.Models;

namespace Ws_Agenda.Helpers
{
    public class JwtHelper
    {
        private readonly byte[] secret;
        public JwtHelper(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }
        public string GetToken(User user)
        {

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.User_Email));
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(createdToken);
        }
    }
}
