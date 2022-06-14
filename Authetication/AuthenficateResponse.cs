using Ws_Agenda.Models;

namespace Ws_Agenda.Authetication
{
    public class AuthenficateResponse
    {
        public string User_Email { get; set; }  

        public string Token { get; set; }

        public AuthenficateResponse(User user, string token)
        {   
            User_Email = user.User_Email;
            Token = token;
          
        }
    }

   
}
