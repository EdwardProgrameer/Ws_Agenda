namespace Ws_Agenda.Models
{
    public class User_Registrer
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string User_LastName { get; set; }
        public DateTime? User_BirthDate { get; set; }
        public int User_Phone { get; set; } 
        public byte[] User_photo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
