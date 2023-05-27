using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace user_api.DTO
{
    [DataContract]
    public class CreateUserDTO
    {

        private string password;

        private string email;

        private string name;

        private string userName;

        private int age;


        public CreateUserDTO()
		{
        }

        [Required(ErrorMessage = "Must provide a Email Address!")]
        [EmailAddress(ErrorMessage = "Must be a valid Email Address!")]
        [DataMember(Name = "email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Must provide a User Name!")]
        [MinLength(3, ErrorMessage = "Must provide a Name bigger than 3 characters!")]
        [RegularExpression(@"[A-Za-z ]{3,}", ErrorMessage = "User Name must contain only letters!")]
        [DataMember(Name = "user_full_name")]
        [JsonPropertyName("user_full_name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Required]
        [MinLength(3, ErrorMessage = "Must provide a username bigger than 3 characters!")]
        [MaxLength(24, ErrorMessage = "Must provide a username not greater than 24 characters!")]
        [RegularExpression(@"[A-Za-z0-9_]{3,24}", ErrorMessage = "User Name must be in the right format")]
        [DataMember(Name = "login_name")]
        [JsonPropertyName("login_name")]
        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember(Name = "user_age")]
        [JsonPropertyName("user_age")]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        [Required]
        [DataMember(Name = "user_password")]
        [MinLength(8, ErrorMessage = "Password must have at least 8 characters!")]
        [MaxLength(24, ErrorMessage = "Password must have maximum 24 characters!")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}

