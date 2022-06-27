using System.ComponentModel.DataAnnotations;

namespace Ws_Agenda.DTOs
{
    public class UserDto
    {
        [Key]
        public int User_Id { get; set; }
        [EmailAddress]
        public string User_Email { get; set; }
        public string User_Name { get; set; }
        public string User_LastName { get; set; }
        public DateTime User_BirthDate { get; set; }
        public string User_Phone { get; set; }
        public byte[]? User_Photo { get; set; }
  

    }
}
