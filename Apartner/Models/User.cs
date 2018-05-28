using System;

namespace Apartner.Models
{
    public class User
    {
        private string m_UserName;
        private string m_Password;

        public string Username { get => m_UserName; set => m_UserName = value; }
        public string Password { get => m_Password; set => m_Password = value; }

        public bool IsUserSignedUp()
        {
            //TODO: implement a call to server to find user in server
            return true;
        }

        public void SignUpUser()
        {
            //TODO: implement a call to add user to server
        }
    }
}
