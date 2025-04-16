using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SportClub.Api.Endpoints;
using SportClub.Domain.Entities;


//using SportClub.Api.Endpoints;
using SportClub.Infrastructure.Extensions;
using SportClub.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(); 
builder.Services.AddPersistence("Data Source=sportclub.db");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityCore<IdentityUser>().AddUserManager<UserManager<IdentityUser>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("myAllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Build the app
var app = builder.Build();

// Automatically apply migrations (optional)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}



// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("myAllowSpecificOrigins");
}

app.UseHttpsRedirection();


// Register endpoints
app.MapUserEndpoints();
app.MapIdentityEndpoints();

app.Run();
