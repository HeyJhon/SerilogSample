namespace WorkerServiceSeriLog
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Ejecutando tarea X: {time}", DateTimeOffset.Now);
                    Tarea();
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void Tarea()
        {
            _logger.LogError("Ocurrio un error al ejecutar");
        }
    }
}
