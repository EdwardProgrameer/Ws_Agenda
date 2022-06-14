using Ws_Agenda.Authetication;
using Ws_Agenda.Helpers;
using Ws_Agenda.Models;

namespace Ws_Agenda.Interfaces
{
    public interface IUserInterface
    {
       Task<AuthenficateResponse>Auth(AuthenticateRequest model);

       Task<User>GetById(int id);
    }
}
