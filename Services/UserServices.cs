
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
        //metodo para obtener clientes por el Id
        public async Task<User> GetById(int id)
        {
            return await context.tb_users.AsNoTracking()
                .FirstOrDefaultAsync(x => x.User_Id == id);
        }
        //aqui creo un nuevo usuario
        public async Task<User> AddUser(User user)
        {
            var UserExist = await context.tb_users.AsNoTracking()
                .SingleOrDefaultAsync(x => x.User_Email == user.User_Email);
            if (UserExist != null)
            {
                return null;
            }

             User users = new User
            {
     
            User_Email = user.User_Email,
            User_Name = user.User_Name,
            User_LastName = user.User_LastName,
            User_Password =  Encrypt.ConvertToEncrypt(user.User_Password),
            User_Age = user.User_Age,
            User_Phone = user.User_Phone,
            User_Photo = user.User_Photo,
            User_State = user.User_State

        };

            context.tb_users.Add(users);
            await context.SaveChangesAsync();
            return user;
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


    }
}
