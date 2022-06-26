using Ws_Agenda.Helpers;

namespace Ws_Agenda.DTOs
{
    public class UserCreateDto
    {
        public string User_Email { get; set; }
        public string User_Name { get; set; }
        public string User_LastName { get; set; }
        public string User_Password { get; set; } 
        public DateTime User_BirthDate { get; set; }
        public int User_Age { get; set; }
        public string User_Phone { get; set; }
        public byte[]? User_Photo { get; set; }
       
    }
}
 