using DockerPractice;
using DockerPractice.Services;
using DockerPractice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://*:80");

// Add services to the container.
var server = builder.Configuration["DBServer"] ?? "ms-sql-server";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPasword"] ?? "strongpassword!@#123";
var database = builder.Configuration["Database"] ?? "DockerPracticeDB";

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer($"Server={server}, {port};Initial Catalog={database};User={user};Password={password}"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<RecipeService>();
//builder.Services.AddSingleton<IRecipeService, RecipeService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
//DatabaseManagementService.MigrationInit(app);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
DatabaseManagementService.MigrationInit(app);


//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<AppDBContext>();
//    if (context.Database.GetPendingMigrations().Any())
//    {
//        context.Database.Migrate();
//    }
//}


app.Run();


