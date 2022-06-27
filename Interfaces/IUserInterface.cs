using Ws_Agenda.Authetication;
using Ws_Agenda.DTOs;
using Ws_Agenda.Helpers;
using Ws_Agenda.Models;

namespace Ws_Agenda.Interfaces
{
    public interface IUserInterface
    {
        //aqui tengo mis servicios 
        Task<AuthenficateResponse>Auth(AuthenticateRequest model);
        Task<User>GetById(int id);
        Task<User> AddUser(UserCreateDto userCreateDto);
        Task<User> UpdateUser( UserDto userDto);   
        Task<User> DeleteUser(int id);    
        Task<User> Restaurar(int id);
        Task<User> ChangePassword(ChangePasswordDto passwordDto);
        Task<User> RecoveryPassword(RecoveryPasswordDto recovery);
        Task<User> RecoveryPassword2(RecoveryPassword2Dto recovery2);


    }
}
