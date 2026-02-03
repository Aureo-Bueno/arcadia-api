using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ArcadiaApi.Infrastructure.Interceptors;

public class SlowQueryInterceptor : DbCommandInterceptor
{
  private readonly ILogger<SlowQueryInterceptor> _logger;

  public SlowQueryInterceptor(ILogger<SlowQueryInterceptor> logger)
  {
    _logger = logger;
  }
  
  private const int SlowQueryThreshold = 200;

  public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
  {
    if (eventData.Duration.TotalMilliseconds > SlowQueryThreshold)
    {
      _logger.LogInformation($"Slow query duration: {eventData.Duration.TotalMilliseconds}, command: {command.CommandText}");
    }
    
    return base.ReaderExecuted(command, eventData, result);
  }
}
