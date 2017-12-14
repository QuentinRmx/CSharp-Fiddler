namespace CSharpFiddler.Analyze
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class ExceptionAnalyzer : BaseAnalyzer
    {
        /// <summary>
        /// Gets all footprints for the given exception.
        /// </summary>
        /// <param name="exception">
        /// The exception that contains the footprints.
        /// </param>
        /// <returns>
        /// The description of the footprints, written in a human way.<see cref="string"/>.
        /// </returns>
        public static string GetAllFootprints(Exception exception)
        {
            // TODO: Améliorer traceString.
            var st = new StackTrace(exception, true);
            StackFrame[] frames = st.GetFrames();
            string traceString = string.Empty;
            if (frames == null)
            {
                return traceString;
            }

            foreach (StackFrame frame in frames)
            {
                if (frame.GetFileLineNumber() < 1)
                {
                    continue;
                }

                traceString += "File: " + frame.GetFileName() + ", Method:" + frame.GetMethod().Name + ", LineNumber: "
                               + frame.GetFileLineNumber();

                traceString += (frames.ToList().IndexOf(frame) != frames.Length - 1) ? "  -->  " : string.Empty;
            }

            return traceString;
        }

        public override AnalysisReport PerformAnalysis()
        {
            throw new NotImplementedException();
        }
    }
}
