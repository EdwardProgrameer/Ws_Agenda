using System.ComponentModel.DataAnnotations;

namespace Ws_Agenda.DTOs
{
    public class RecoveryPassword2Dto
    {

        [EmailAddress]
        public string User_Email { get; set; }
        [MaxLength(16), MinLength(8)]
        public string User_Password { get; set; }
        [Compare("User_Password")]
        public string Confirm_Password { get; set; }

        

    }
}
