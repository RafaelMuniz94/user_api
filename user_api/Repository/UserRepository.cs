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

        public async Task<User> FindByID(Guid id)
        {
            try
            {
                User user = userContext.Users.Where(u => u.ID == id).FirstOrDefault();
                return user;

            }catch(Exception e)
            {
                throw;
            }
        }

        public async Task<User> FindByLogin(string login)
        {
            try
            {
                User user = userContext.Users.Where(u => u.Username == login).FirstOrDefault();
                return user;

            }
            catch (Exception e)
            {
                throw;
            }
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

        public async Task<bool> Delete(User user)
        {
            try
            {

                userContext.Remove(user);
                return userContext.SaveChanges() > 0 ? true : false;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<User> FindByEmail(string email)
        {
            try {
                User user = userContext.Users.Where(u => u.Email == email).FirstOrDefault();
                return user;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}