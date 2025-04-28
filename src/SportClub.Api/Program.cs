using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportClub.Api.Endpoints;


//using SportClub.Api.Endpoints;
using SportClub.Infrastructure.Extensions;
using SportClub.Infrastructure.Identity;
using SportClub.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddPersistence(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});
#endif

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
    app.UseCors();
}

app.UseHttpsRedirection();


// Register endpoints
app.MapUserEndpoints();
app.MapIdentityEndpoints();

app.Run();
