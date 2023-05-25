using System;
using user_api.Models;
using user_api.Repository.Context;
using user_api.Repository.Interfaces;

namespace user_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(UserContext context)
        {
            userContext = context;
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                await userContext.AddAsync(user);
                return userContext.SaveChanges() > 0 ? true : false;

            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}