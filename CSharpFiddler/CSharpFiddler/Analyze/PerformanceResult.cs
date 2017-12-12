// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceResult.cs" company="Evanzyker Devlab">
//   Created By Evanzyker
// </copyright>
// <summary>
//   Contains some datas about a specific function's performances.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpFiddler.Analyze
{
    /// <summary>
    /// Contains some datas about a specific function's performances. It is used by the TestHelpers methods.
    /// </summary>
    public class PerformanceResult
    {
        /// <summary>
        /// Execution time in milliseconds.
        /// </summary>
        public double TimeElapsed { get; set; }

        /// <summary>
        /// Tested method's name.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceResult"/> class.
        /// </summary>
        public PerformanceResult()
        {
            this.TimeElapsed = -1;
            this.MethodName = "Method not set";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceResult"/> class.
        /// </summary>
        /// <param name="elapsed">
        /// The elapsed time during execution.
        /// </param>
        /// <param name="methodName">
        /// The method name.
        /// </param>
        public PerformanceResult(double elapsed, string methodName)
        {
            this.TimeElapsed = elapsed;
            this.MethodName = methodName;
        }

        /// <summary>
        /// Returns a readable description for the performance results.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public new string ToString()
        {
            return $"Method [{this.MethodName}] executed in: {this.TimeElapsed}ms.";
        }
    }
}