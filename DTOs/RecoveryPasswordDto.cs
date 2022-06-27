using System.ComponentModel.DataAnnotations;

namespace Ws_Agenda.DTOs
{
    public class RecoveryPasswordDto
    {
        [EmailAddress]
        public string User_Email { get; set; }

    }
}
