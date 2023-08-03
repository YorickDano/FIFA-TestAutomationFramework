namespace Core.Utils
{
    using Microsoft.Extensions.Logging;
    using Serilog;
    using Serilog.Extensions.Logging;

    public class Logger
    {
        private static readonly ILoggerFactory factory;
        private static readonly Microsoft.Extensions.Logging.ILogger logger;

        static Logger()
        {
            factory = new SerilogLoggerFactory(new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger());
            logger = factory.CreateLogger<Logger>();
        }

        public static void Info(string logMessage)
        {
            logger.LogInformation(logMessage);
        }

        public static void Debug(string logMessage)
        {
            logger.LogDebug(logMessage);            
        }

        public static void Warning(string logMessage)
        {
            logger.LogWarning(logMessage);
        }
    }
}
