
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ws_Agenda.Authetication;
using Ws_Agenda.DTOs;
using Ws_Agenda.Helpers;
using Ws_Agenda.Interfaces;
using Ws_Agenda.Models;

namespace Ws_Agenda.Services
{

    public class UserServices : IUserInterface
    {

        private readonly ApplicationDbContext context;
        private readonly IConfiguration conf;
        private readonly IMapper mapper;    

        public UserServices(ApplicationDbContext _context, IConfiguration configuration , IMapper mapper)
        {
            this.context = _context;
            this.conf = configuration;
            this.mapper = mapper;

        }
        //aqui desencripto la contrasena y valido el usuario 
        public async Task<AuthenficateResponse> Auth(AuthenticateRequest model)
        {

            var user = await context.tb_users.AsNoTracking()
                .SingleOrDefaultAsync(x => x.User_Email == model.user_email);
            if (user is null)
            {
                return null;
            }

            string user_password = Encrypt.ConvertToDescrypt(user.User_Password);
            if (user_password != model.password)
            {
                return null;
            }

            string secret = this.conf.GetValue<string>("SecretKey");
            var jwtHelpers = new JwtHelper(secret);
            string token = jwtHelpers.GetToken(user);


            return new AuthenficateResponse(user, token);

        }
        //metodo para obtener usuarios por el Id
        public async Task<User> GetById(int id)
        {
            return await context.tb_users.AsNoTracking()
                .FirstOrDefaultAsync(x => x.User_Id == id);
        }
        //aqui creo un nuevo usuario
        public async Task<User> AddUser(UserCreateDto userCreateDto)
        {
            var UserExist = await context.tb_users.AsNoTracking()
                .SingleOrDefaultAsync(x => x.User_Email == userCreateDto.User_Email);
            if (UserExist != null)
            {
                return null;
            }


            userCreateDto.User_Password = Encrypt.ConvertToEncrypt(userCreateDto.User_Password);
            var user = mapper.Map<User>(userCreateDto);
            context.Add(user);
            await context.SaveChangesAsync();
            return (user);
        }
        //aqui edito mi usuario
        public async Task<User> UpdateUser(UserDto userDto)
        {
            var userDB = await context.tb_users.FirstOrDefaultAsync(x => x.User_Id == userDto.User_Id);
            if (userDB is null)
            {
                return null;
            }
         
            userDB = mapper.Map(userDto, userDB);
            await context.SaveChangesAsync();
            return (userDB);
           
        }
        //aqui elimino un usuario 
        public async Task<User> DeleteUser(int id)
        {
           var userDelete = await context.tb_users.FirstOrDefaultAsync(x => x.User_Id == id);
            if (userDelete is null)
            {
                return null;
            }

            userDelete.User_State = true;
            await context.SaveChangesAsync();
            return userDelete;
        }
        //aqui lo reactivo
        public async Task<User>Restaurar(int id)
        {
            var userDelete = await context.tb_users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.User_Id == id);
            if (userDelete is null)
            {
                return null;
            }

            userDelete.User_State = false;
            await context.SaveChangesAsync();
            return userDelete;
        }

        //aqui cambio la contrasena del usuario
        public async Task<User>ChangePassword(ChangePasswordDto passwordDto)
        {
            passwordDto.Old_Password = Encrypt.ConvertToEncrypt(passwordDto.Old_Password);
            var userDB = await context.tb_users.FirstOrDefaultAsync(x => x.User_Id == passwordDto.User_Id && x
            .User_Password == passwordDto.Old_Password );

            if (userDB is null)
            { return null;}

            passwordDto.User_Password = Encrypt.ConvertToEncrypt(passwordDto.User_Password);
            userDB = mapper.Map(passwordDto,userDB);
            await context.SaveChangesAsync(); 
            return (userDB);  

        }

        public async Task<User>RecoveryPassword(RecoveryPasswordDto recovery)
        {
            string UrlDomain = this.conf.GetValue<string>("UrlDomain");
            string token = Encrypt.ConvertToEncrypt(Guid.NewGuid().ToString());
            var userDB = await context.tb_users.FirstOrDefaultAsync(x =>x.User_Email == recovery.User_Email);
            if (userDB is null)
            {
                return null;
            }

            userDB.Token_Recovery = token;
            userDB = mapper.Map(recovery,userDB);
            await context.SaveChangesAsync();
            MailHerper.SendMail(userDB.User_Email,token,UrlDomain);
            return (userDB);

           

        }

        public async Task<User>RecoveryPassword2(RecoveryPassword2Dto recovery2)
        {
            var userDB = await context.tb_users.FirstOrDefaultAsync(x =>x.User_Email == recovery2.User_Email && x.
            Token_Recovery != null);
            if (userDB is null)
            { return null;}

            recovery2.User_Password = Encrypt.ConvertToEncrypt(recovery2.User_Password);
            userDB.Token_Recovery = null;
            userDB = mapper.Map(recovery2, userDB);
            await context.SaveChangesAsync();
            return(userDB);
        }

    }
}
