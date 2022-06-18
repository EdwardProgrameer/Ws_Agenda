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
        private readonly IConfiguration conf;
     
        public UserServices(ApplicationDbContext _context , IConfiguration configuration)
        {
            this.context = _context;
            this.conf = configuration;
         
        }
        //aqui desencripto la contrasena y valido el usuario 
        public async Task<AuthenficateResponse> Auth(AuthenticateRequest model)
        {

            var user = await context.tb_users.Where(x => x.User_Email == model.user_email).
                Include(X => X.User_Registrer)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            string user_password = Encrypt.ConvertToDescrypt(user.User_Password);
            if(user_password != model.password)
            {
                return null;
            }

            string secret = this.conf.GetValue<string>("SecretKey");
            var jwtHelpers = new JwtHelper(secret);
            string token = jwtHelpers.GetToken(user);


            return new AuthenficateResponse(user,token);

        }
        //metodo para obtener clientes por el Id
        public async Task<User> GetById(int id)
        {
            return await context.tb_users.FirstOrDefaultAsync(x => x.User_Id == id);
        }

    }
}
