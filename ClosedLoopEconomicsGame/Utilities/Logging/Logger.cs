namespace ClosedLoopEconomicsGame.Utilities.Logging
{
    public static class Logger
    {
        private static readonly List<ILoggingService> _loggingServices;

        static Logger()
        {
            _loggingServices = new List<ILoggingService>
            {
                new FileLoggingService("logs")
            };
        }

        public static void Add(ILoggingService service)
        {
            _loggingServices.Add(service);
        }

        public static void Log(string message)
        {
            foreach (var loggingService in _loggingServices)
                loggingService.Log(message);
        }

        public static void Log(Exception exception, string message = null)
        {
            foreach (var loggingService in _loggingServices)
                loggingService.Log(exception, message);
        }
    }
}
