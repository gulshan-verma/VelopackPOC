using System;
using System.IO;

namespace VelopackPOC
{
    public static class LogHelper
    {
        public static void LogEvents(LoggingType logType, string message)
        {
            var eventLog = $"[{DateTime.Now}] {logType.ToString()}: {message}" + Environment.NewLine;
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VelopackPOCEvents.txt"), eventLog);
            Console.WriteLine(message);
        }

        public enum LoggingType
        {
            Info = 0,
            Error = 1
        }
    }
}