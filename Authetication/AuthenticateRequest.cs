using System.ComponentModel.DataAnnotations;

namespace Ws_Agenda.Authetication
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress]
        public string user_email { get; set; }
        [Required(ErrorMessage = "The Password field is required")]
        public string password { get; set; }
    }
}
 