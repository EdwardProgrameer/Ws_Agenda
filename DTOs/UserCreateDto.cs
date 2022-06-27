using System.ComponentModel.DataAnnotations;
using Ws_Agenda.Helpers;

namespace Ws_Agenda.DTOs
{
    public class UserCreateDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "The Email field is required")]
        public string User_Email { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "The last name field is required")]
        public string User_LastName { get; set; }

        [Required(ErrorMessage = "The password field is required")]
        [MaxLength(16),MinLength(8)]
        public string User_Password { get; set; }

        [Required(ErrorMessage = "The user birthdate field is required")]
        public DateTime User_BirthDate { get; set; }

        [Required(ErrorMessage = "The phone field is required")]
        public string User_Phone { get; set; }
        public byte[]? User_Photo { get; set; }
       
    }
}
 