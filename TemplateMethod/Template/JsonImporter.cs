using System.Text.Json;
using TemplateMethod.Common.Services;
using TemplateMethod.Template.TemplateBase;

namespace TemplateMethod.Template;

public class JsonImporter : FileImporterBase
{
    protected async override Task<IList<T>> ExtractAsync<T>()
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
        {
            return await JsonSerializer.DeserializeAsync<List<T>>(stream, options);
        }
    }
}
