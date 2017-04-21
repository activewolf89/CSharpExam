

using System;
using System.ComponentModel.DataAnnotations;

namespace ProfessionalNetwork.Models
{
    public class Network
    {
        public int NetworkId {get;set;}
        public DateTime Created_At {get;set;}

        public int UserConnectedId{get;set;}
        public User UserConnected{get;set;}
        public int UserId{get;set;}
        public User User{get;set;}
        public string Status{get;set;}

    }
}