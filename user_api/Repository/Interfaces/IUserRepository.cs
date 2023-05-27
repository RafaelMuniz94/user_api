using System;
using user_api.Models;

namespace user_api.Repository.Interfaces
{
	public interface IUserRepository
	{
		Task<bool> Register(User user);
        Task<User> FindByID(Guid id);
        Task<User> FindByLogin(string login);
        Task<User> FindByEmail(string email);
        Task<bool> Delete(User user);
    }
}

