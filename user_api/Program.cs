using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Json;
using user_api.Middlewares;
using user_api.Repository;
using user_api.Repository.Context;
using user_api.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//builder.Services.ConfigureUserContext();
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("UserDatabase"));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new JsonFormatter(null, true, null))
    .Enrich.WithProperty("ExcecutionID0", Guid.NewGuid())
    .Enrich.FromLogContext().CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

