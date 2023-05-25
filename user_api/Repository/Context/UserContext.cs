using System;
using Microsoft.EntityFrameworkCore;
using user_api.Models;

namespace user_api.Repository.Context
{
	public class UserContext:DbContext
	{
		public DbSet<User> User { get; set; }

		public UserContext(DbContextOptions options): base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<User>().HasKey(u => new
			{
				u.ID
			});
        }
    }
}

