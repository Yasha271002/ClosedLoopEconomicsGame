namespace ClosedLoopEconomicsGame.Utilities.Logging
{
    public interface ILoggingService
    {
        void Log(string message);

        void Log(Exception exception, string message = null);
    }

}
