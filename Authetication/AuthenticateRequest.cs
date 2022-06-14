using System.ComponentModel.DataAnnotations;

namespace Ws_Agenda.Authetication
{
    public class AuthenticateRequest
    {
        [Required]
        public string user_email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
