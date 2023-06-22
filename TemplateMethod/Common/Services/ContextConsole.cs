using TemplateMethod.Common.Models;

namespace TemplateMethod.Common.Services
{
    public class ContextConsole
    {
        public static void WriteReport(string filePath, EtlResults etlResults)
        {
            Console.WriteLine($"====================================================");
            Console.WriteLine($"FILE IMPORT STATISTICS /////////////////////////////");
            Console.WriteLine($"====================================================");
            Console.WriteLine($"Status: {etlResults.Status}");

            if (!string.IsNullOrEmpty(etlResults.Error)) 
            { 
                Console.WriteLine($"Error: {etlResults.Error}"); 
            }

            Console.WriteLine($"Source file: {filePath}");
            Console.WriteLine($"Processing time: {etlResults.Time}");
            Console.WriteLine($"Row count: {etlResults.RowCount}");
            Console.WriteLine($"====================================================");
            Console.WriteLine();
        }
    }
}
