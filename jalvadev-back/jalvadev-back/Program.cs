using jalvadev_back.Repositories;
using jalvadev_back.Repositories.Database;
using jalvadev_back.Repositories.Interfaces;
using jalvadev_back.Resources;
using jalvadev_back.Services;
using jalvadev_back.Services.Interfaces;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IConnectionProvider, ConnectionProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IPostService,  PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

// CONFIGURATION: AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CONNECTION STRING FOR NLOG.
string filePath = builder.Configuration["PasswordsFile"];
if (!File.Exists(filePath))
    throw new Exception(Resource.api_error_password_file_not_found);

string password = File.ReadAllText(filePath);

LogManager.Configuration.Variables["pass"] = password;

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service cors for development.
builder.Services.AddCors(c => c.AddPolicy("AllowSpecificOrigin", builder =>
{
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigin");
    Console.WriteLine("Development Env.");
}

if(app.Environment.IsStaging())
{
    Console.WriteLine("Staging Env.");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
