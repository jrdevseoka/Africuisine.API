
using Serilog;

namespace Africuisine.Infrastructure.Services.Log
{
    public class Log : ILog
    {
        private readonly ILogger Logger;

        public Log(ILogger logger)
        {
            Logger = logger;
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, object exception)
        {
            Logger.Error(message, exception);
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }
    }
}