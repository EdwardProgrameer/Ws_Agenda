using System.ComponentModel.DataAnnotations;

namespace Ws_Agenda.DTOs
{
    public class ChangePasswordDto
    {

        public int User_Id { get; set; }
        [Required]
        public string User_Password { get; set; }
        public string Old_Password { get; set; }

    }
}
