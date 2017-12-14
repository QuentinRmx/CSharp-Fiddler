namespace CSharpFiddler.Analyze
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class PerformanceAnalyzer : BaseAnalyzer
    {
        /// <summary>
        /// Executes a method, mesures the execution time and return a PerformanceResult object containing these datas.
        /// </summary>
        /// <param name="function">
        /// The function that will be executed and mesured.
        /// </param>
        /// <returns>
        /// The test result. It contains the method name and the execution time. <see cref="PerformanceResult"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Returned if the function is null.
        /// </exception>
        public static PerformanceResult ExecuteAndTime(Action function)
        {
            if (function == null)
            {
                throw new InvalidOperationException();
            }

            var watch = new Stopwatch();
            watch.Start();
            function.Invoke();
            watch.Stop();
            return new PerformanceResult(watch.ElapsedMilliseconds, function.Method.Name);
        }

        /// <summary>
        /// Executes a method a certain number of times, mesures the execution time and return a PerformanceResult object containing these datas.
        /// </summary>
        /// <param name="function">
        /// The function that will be executed and mesured.
        /// </param>
        /// <param name="count">
        /// The number of times the function will be executed.
        /// </param>
        /// <returns>
        /// A list of test results. Each one contains the method name and the execution time for one run. <see cref="PerformanceResult"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Exception thrown if the function is null or the count is inferior or equal to zero.
        /// </exception>
        public static List<PerformanceResult> LoopExecuteAndTime(Action function, int count)
        {
            if (count <= 0 || function == null)
            {
                throw new InvalidOperationException();
            }

            List<PerformanceResult> results = new List<PerformanceResult>(count);

            var watch = new Stopwatch();
            for (var i = 0; i < count; i++)
            {
                watch.Start();
                function.Invoke();
                watch.Stop();
                results.Add(new PerformanceResult(watch.ElapsedMilliseconds, function.Method.Name));
                watch.Reset();
            }

            return results;
        }

        /// <summary>
        /// Writes in console PerfResults datas. If advancedDatas is set to true, then display additionnal computed datas.
        /// </summary>
        /// <param name="results">
        /// The results that will be displayed.
        /// </param>
        /// <param name="advancedDatas">
        /// If sets to true, display advanced datas, like average execution time.
        /// </param>
        public static void DisplayPerfResults(List<PerformanceResult> results, bool advancedDatas = false)
        {
            if (results == null || !results.Any())
            {
                Console.WriteLine("Performances datas are invalid and cannot be displayed.");
                return;
            }

            Console.WriteLine($"===== PERFORMANCE TEST RESULTS [{results.First().MethodName}] executed {results.Count} times =====");
            foreach (PerformanceResult perfResult in results)
            {
                Console.WriteLine(perfResult.ToString());
            }

            if (!advancedDatas)
            {
                return;
            }

            List<double> times = results.Select(r => r.TimeElapsed).ToList();
            double averageSpeed = times.Average();
            double longest = times.Max();
            double shortest = times.Min();
            Console.WriteLine($"Average execution time: {averageSpeed}ms.");
            Console.WriteLine($"Longest execution time: {longest}ms");
            Console.WriteLine($"Shortest execution time: {shortest}ms");
        }

        public override AnalysisReport PerformAnalysis()
        {
            throw new NotImplementedException();
        }
    }
}
