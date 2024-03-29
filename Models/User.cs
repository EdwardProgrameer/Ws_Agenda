﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Ws_Agenda.Helpers;

namespace Ws_Agenda.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }  
        public string User_Email { get; set; }
        public string User_Name { get; set; } 
        public string User_LastName { get; set; }
        public string User_FullName
        {
            get { return User_Name + " " + User_LastName; }
        }
        [JsonIgnore]

        public int? User_Age
        {
            get
            {
                if (!User_BirthDate.HasValue)
                {
                    return null;
                }

                var fechaNacimiento = User_BirthDate.Value;

                var age = DateTime.Today.Year - fechaNacimiento.Year;

                if (new DateTime(DateTime.Today.Year, fechaNacimiento.Month, fechaNacimiento.Day) > DateTime.Today)
                {
                    age--;
                }

                return age;
            }
        }
        public string User_Password { get; set; }
        public DateTime? User_BirthDate { get; set; }  
        public string User_Phone { get; set; }
        public byte[]? User_Photo { get; set; }
        public bool User_State { get; set; }
        [JsonIgnore]
        public string Token_Recovery { get; set; }

    }
}
