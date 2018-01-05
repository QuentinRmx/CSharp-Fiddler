namespace CSharpFiddler
{
    using CSharpFiddler.Analyze;
    using Sentinel;
    public class Program
    {
        public static void Main(string[] args)
        {
            Sentinel.Log(System.Reflection.MethodBase.GetCurrentMethod().ToString(), "Test de log");
        }
    }
}
