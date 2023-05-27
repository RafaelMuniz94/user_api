using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace user_api.DTO
{
    [DataContract]
	public class ReturnUserDTO
	{

        private string email;

        private string name;

        private string userName;

        private int age;

        private Guid id;


        public ReturnUserDTO()
		{
        }

        [JsonPropertyName("user_email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [JsonPropertyName("user_name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [JsonPropertyName("user_login")]
        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }

        [JsonPropertyName("user_age")]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        [JsonPropertyName("user_id")]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}

