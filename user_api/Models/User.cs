
using System;


namespace user_api.Models
{


	public class User
	{
		private string password;

		private string email;

		private string name;

        private string userName;

        private int age;

		private Guid id;

		public User()
		{
			id = Guid.NewGuid();
		}


        public string Email
		{
			get { return email; }
			set { email = value; }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}


        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }


        public int Age
		{
			get { return age; }
			set { age = value; }
		}


		public Guid ID
		{
			get { return id; }
            set { id = value; }
        }

        public string Password
		{
			get { return password; }
			set { password = value; }
		}

		
	}
}

