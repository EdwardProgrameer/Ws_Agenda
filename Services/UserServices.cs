using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ws_Agenda.Authetication;
using Ws_Agenda.Helpers;
using Ws_Agenda.Interfaces;
using Ws_Agenda.Models;

namespace Ws_Agenda.Services
{
 
    public class UserServices : IUserInterface
    {

        private readonly ApplicationDbContext context;
        private readonly AppSetting _appSettings;
        private readonly IConfiguration conf;
        private readonly byte[] secret;
        public UserServices(ApplicationDbContext _context , IOptions<AppSetting> appSettings, IConfiguration configuration)
        {
            this.context = _context;
            this._appSettings = appSettings.Value;
            this.conf = configuration;
            string SecretKey = this.conf.GetValue<string>("SecretKey");
            this.secret = Encoding.ASCII.GetBytes(SecretKey);
        }

        //aqui encripto la contrasena y valido el usuario 
        public async Task<AuthenficateResponse> Auth(AuthenticateRequest model)
        {
            
            string user_password = Encrypt.GetSHA256(model.password);
            var user = await context.tb_users.SingleOrDefaultAsync(x => x.User_Email == model.user_email && x.User_Password == user_password);
            if (user == null) return null;

            var token = GetToken(user);
            return new AuthenficateResponse(user,token);
        }

        // aqui obtengo y genero el token
        private string GetToken (User user)
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

        //metodo para obtener clientes por el Id
        public async Task<User> GetById(int id)
        {
            return await context.tb_users.FirstOrDefaultAsync(x => x.User_Id == id);
        }

    }
}
