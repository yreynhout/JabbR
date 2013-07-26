namespace JabbR.Infrastructure
{
    public interface ILogger
    {
        void Log(LogType type, string message);
    }
}