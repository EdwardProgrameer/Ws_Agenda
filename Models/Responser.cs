namespace Ws_Agenda.Models
{
    public class Responser
    {
        public string User_Email { get; set; }
        public string Token { get; set; }
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string User_LastName { get; set; }
        public DateTime? User_BirthDate { get; set; }
        public int User_Age { get; set; }
        public int User_Phone { get; set; }
        public byte[] User_photo { get; set; }
        public User User { get; }
    }
}
