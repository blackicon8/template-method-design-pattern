using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TemplateMethod.Common.Services;
using TemplateMethod.Template.TemplateBase;

namespace TemplateMethod.Template;

public class CsvImporter : FileImporterBase
{
    protected async override Task<IList<T>> ExtractAsync<T>()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
        };

        using (var stream = new StreamReader(FilePath))
        {
            using (var csv = new CsvReader(stream, config))
            {
                var results = await Task.Run(() => csv.GetRecords<T>().ToList());
                return results;
            }
        }
    }
}