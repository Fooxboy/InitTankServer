using System;
using System.Collections.Generic;
using System.Text;

namespace InitTankServer.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  string Token { get; set; }
    }
}
