using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta
{
    public static class ConsoleLogger
    {
        /// <summary>
        /// Logs a message in green with a line break after
        /// </summary>
        public static void LogSuccess(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Logs a message in red with a line break after
        /// </summary>
        public static void LogFailure(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Logs a message with a line break after
        /// </summary>
        public static void LogInformationSpaced(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
        /// <summary>
        /// Logs a message with no line break
        /// </summary>
        public static void LogInformationUnspaced(string message)
        {
            Console.WriteLine(message);
        }
    }
}
