using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Serilog;
using Serilog.Context;
using Newtonsoft.Json;

namespace user_api.Middlewares
{
	public class ErrorHandlingMiddleware
	{

		private readonly RequestDelegate _next;
		private const string TokenRemoveKeyName = "Authorization";


		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			using (LogContext.PushProperty(TokenRemoveKeyName, string.Empty))
			{
				try
				{
					await _next(httpContext);
				}catch(Exception e)
				{
					await HandleException(httpContext, e);
                }
			}
		}

		private static Task HandleException(HttpContext httpContext,Exception e)
		{
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            Log.Error($"Error: {e.Message}");
            Log.Error($"Stack: {e.StackTrace}");

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;

			IDictionary<string, string> response = new Dictionary<string, string>()
			{
				{"Message", "Internal Error!" },

            };

			return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
	}
}

