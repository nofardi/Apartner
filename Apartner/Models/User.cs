using System;

namespace Apartner.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool isUserSignedUp()
        {
            //TODO: implement a call to server
            return true;
        }
    }
}
