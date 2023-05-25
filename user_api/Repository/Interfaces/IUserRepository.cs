using System;
using user_api.Models;

namespace user_api.Repository.Interfaces
{
	public interface IUserRepository
	{
		Task<bool> Register(User user);
	}
}

