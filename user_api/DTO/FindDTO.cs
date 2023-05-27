using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace user_api.DTO
{
	public class FindDTO
	{
        private string email;

        private string userName;

        public FindDTO()
		{
		}

        
        [EmailAddress(ErrorMessage = "Must be a valid Email Address!")]
        [DataMember(Name = "email")]
        [FromQuery(Name = "user_email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        
        [MinLength(3, ErrorMessage = "Must provide a username bigger than 3 characters!")]
        [MaxLength(24, ErrorMessage = "Must provide a username not greater than 24 characters!")]
        [RegularExpression(@"[A-Za-z0-9_]{3,24}", ErrorMessage = "User Name must be in the right format")]
        [DataMember(Name = "login")]
        [FromQuery(Name = "user_login")]
        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}

