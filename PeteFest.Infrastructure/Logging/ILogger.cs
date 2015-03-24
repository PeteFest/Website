using System;

namespace PeteFest.Infrastructure.Logging
{
    public interface ILogger
    {
        void LogError(string message);

        void LogInformation(string message);

        void LogWarning(Exception ex);

        void LogError(Exception ex);
    }
}
