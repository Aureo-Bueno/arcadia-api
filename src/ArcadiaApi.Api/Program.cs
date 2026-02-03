using Microsoft.EntityFrameworkCore;
using ArcadiaApi.Api.Configuration;
using ArcadiaApi.Application;
using ArcadiaApi.Infrastructure;
using ArcadiaApi.Infrastructure.Persistence;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

  builder.Services.AddApi();
  builder.Services.AddApplication();
  builder.Services.AddInfrastructure(connectionString);
}

WebApplication? app = builder.Build();
{
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  app.MapGraphQL("/graphql");

  using (var scope = app.Services.CreateScope())
  {
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var logger = app.Logger;

    const int maxRetries = 10;
    var delay = TimeSpan.FromSeconds(2);
    var attempt = 0;

    while (true)
    {
      try
      {
        dbContext.Database.Migrate();
        break;
      }
      catch (Exception ex) when (attempt < maxRetries)
      {
        attempt++;
        logger.LogWarning(ex, "Database not ready (attempt {Attempt}/{Max}). Retrying in {Delay}s...", attempt, maxRetries, delay.TotalSeconds);
        Thread.Sleep(delay);
        delay = TimeSpan.FromSeconds(Math.Min(delay.TotalSeconds * 2, 30));
      }
    }
  }

  app.Run();
}
