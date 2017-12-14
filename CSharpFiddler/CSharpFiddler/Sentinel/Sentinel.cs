// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sentinel.cs" company="Evanzyker Devlab">
//   
// </copyright>
// <summary>
//   The Sentinel main file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpFiddler.Sentinel
{
    using System;

    /// <summary>
    /// Sentinel is a log tool designed to be used anywhere in a program. Its goal is to provide a generic and optimized logger.
    /// It follows the traditionnal Singleton pattern.
    /// </summary>
    public class Sentinel
    {

        private static Sentinel instance;

        public static Sentinel Instance => instance ?? (instance = new Sentinel());

        public static Sentinel Log(string message)
        {
            // TODO: Log the message
            Console.WriteLine($"Sentinel Log >> {message}");
            return Instance;
        }
    }
}
