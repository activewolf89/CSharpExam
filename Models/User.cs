

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessionalNetwork.Models
{
    public class User
    {
        public User()
        {
            UsersConnectedToList = new List<Network>();
            Networks = new List<Network>();
        }

        public int UserId {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public DateTime Created_At {get;set;}
        public string Description {get;set;}
         public List<Network> Networks{get;set;}

        [InverseProperty("UserConnected")]
        public List<Network> UsersConnectedToList{get;set;}
    }
}