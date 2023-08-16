using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Notes.WebApi.Services
{
    public class LogAnalysisService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                
                await Task.Delay(20_000, stoppingToken);
            }
            await Task.CompletedTask;
        }
    }
}
