using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace user_api.DTO
{
	public class DeleteUserDTO
	{

        private string password;
        private Guid id;

        public DeleteUserDTO()
		{
		}

        [Required]
        [DataMember(Name = "user_id")]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
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

