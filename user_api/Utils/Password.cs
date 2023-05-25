using System;
using System.Security.Cryptography;
using System.Text;

namespace user_api.Utils
{
	public class Password
	{
		public string Cryptograph(string password)
		{
			SHA256 hashCreator = SHA256.Create();
			byte[] hashValue = hashCreator.ComputeHash(Encoding.UTF8.GetBytes(password));
			return Convert.ToHexString(hashValue);
		}

	}
}

