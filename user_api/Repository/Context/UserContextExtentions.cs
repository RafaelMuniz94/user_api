using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace user_api.Repository.Context
{
	[ExcludeFromCodeCoverage]
	public static class UserContextExtentions
	{
		private const string DatabaseName = "UserDatabase";
		private const int DatabasePort = 1500;
		private const string DatabaseEndpoint = "HostEndpoint";
        private const string KeyHost = "Host";
        private const string KeyDatabaseName = "Database";
        private const string KeyPort = "Port";
        private const string KeyUserName = "Username";
        private const string KeyPassword = "Password";
        //      private const string KeySSLMode = "sslmode";
        //      private const string SSLModeRequire = "Require";
        //      private const string TrustServerCertificate = "Trust Server Certificate";
        private const string LocalHostEndpoint = "127.0.0.1";


        public static void ConfigureUserContext(this IServiceCollection services)
		{
			services.AddDbContext<UserContext>(options =>
			{
				options.UseNpgsql(CreateConnectionString());
			});
		}

		public static string CreateConnectionString() {

			DbConnectionStringBuilder builder = new DbConnectionStringBuilder();

#if DEBUG
			builder[KeyHost] = LocalHostEndpoint;
#else
			builder[Keyword] = DatabaseEndpoint;
#endif
			builder[KeyPort] = DatabasePort;
			builder[KeyDatabaseName] = DatabaseName;
            builder[KeyUserName] = Environment.GetEnvironmentVariable("DbUserName");
			builder[KeyPassword] = Environment.GetEnvironmentVariable("DbUserPassword");
			string connectionString =  builder.ConnectionString;
			return connectionString;
		}

	}
}

