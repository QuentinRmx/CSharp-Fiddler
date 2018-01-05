// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sentinel.cs" company="Evanzyker Devlab">
//   Created By Evanzyker
// </copyright>
// <summary>
//   The Sentinel main file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using System.Reflection;

namespace Sentinel
{
    using System;

    /// <summary>
    /// Sentinel is a log tool designed to be used anywhere in a program. Its goal is to provide a generic and optimized logger that gives
    /// useful and precise datas.
    /// It tries to follow the basic concept of log: what happened when by whom.
    /// </summary>
    public class Sentinel
    {

        private const string LogFilePath = @"C:\Users\qrim\Source\Repos\CSharp-Fiddler\CSharpFiddler\CSharpFiddler\Sentinel\Sentinel_Logs.txt";
        
        public static void Log(string message)
        {
            using (var logFile = new StreamWriter(LogFilePath, true))
            {
                logFile.WriteLine($"[{DateTime.Now}] >> {message}");
            }
        }

        public static void Log(string context, string message)
        {
            Sentinel.Log($"{context} : {message}");
        }
    }
}
