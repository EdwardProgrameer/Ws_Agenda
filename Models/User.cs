using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ws_Agenda.Models
{
    public class User
    {
     
        public int User_Id { get; set; }  
        public string User_Email { get; set; }

        [JsonIgnore]
        public string User_Password { get; set; }
        public User_Registrer User_Registrer { get; set; }  

    }
}
