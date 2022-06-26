using Ws_Agenda.Models;

namespace Ws_Agenda.Authetication
{
    public class AuthenficateResponse
    {
        public int User_Id { get; set; }
        public string User_Email { get; set; }
        public string User_Name { get; set; }
        public string User_LastName { get; set; }
        public int User_Age { get; set; }
        public string User_Phone { get; set; }
        public byte[] User_Photo { get; set; }
        public int User_State { get; set; }
        public string Token { get; set; }
        public string User_FullName { get; set; }

        public AuthenficateResponse(User user, string token)
        {

            User_Id = user.User_Id;
            User_Email = user.User_Email;
            User_Name = user.User_Name;
            User_FullName = user.User_FullName;
            User_LastName = user.User_LastName; 
            User_Age = user.User_Age;
            User_Phone = user.User_Phone;
            User_Photo = user.User_Photo;
            Token = token;
          
        }
    }

   
}
