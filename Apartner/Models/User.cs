using System;
using System.Json;
using Newtonsoft.Json;


namespace Apartner.Models
{
    public class User
    {
        // TODO: change according to facebook
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

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Relationship { get; set; }
        public string Gender { get; set; }
        public string ProfilePic { get; set; }
        public string LinkToProfile { get; set; }

        public static User createUserFromFBAPI(JsonObject i_FacebookJson)
        {
            return JsonConvert.DeserializeObject<User>(i_FacebookJson);
        }


    }
}
