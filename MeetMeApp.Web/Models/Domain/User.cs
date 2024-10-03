using System;
using System.Collections.Generic;

namespace MeetingApp.Models.Domain
{
    public class User
    {
        public Guid U_id { get; set; } // Primary Key
        public string Username { get; set; }
        public string Pass { get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
    }
}
