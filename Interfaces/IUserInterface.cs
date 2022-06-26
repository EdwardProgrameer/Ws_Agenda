using Ws_Agenda.Authetication;
using Ws_Agenda.DTOs;
using Ws_Agenda.Helpers;
using Ws_Agenda.Models;

namespace Ws_Agenda.Interfaces
{
    public interface IUserInterface
    {
        Task<AuthenficateResponse>Auth(AuthenticateRequest model);
        Task<User>GetById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser( UserDto userDto);   
        Task<User> DeleteUser(int id);    
        Task<User> Restaurar(int id);
     
    }
}
