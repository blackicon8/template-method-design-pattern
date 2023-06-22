using System.Xml.Serialization;
using TemplateMethod.Common.Services;
using TemplateMethod.Template.TemplateBase;

namespace TemplateMethod.Template;

public class XmlImporter : FileImporterBase
{
    protected async override Task<IList<T>> ExtractAsync<T>()
    {
        if (string.IsNullOrEmpty(FilePath)) return default(IList<T>);

        var xRoot = new XmlRootAttribute();
        xRoot.ElementName = $"ArrayOf{typeof(T).Name}";
        xRoot.IsNullable = true;

        var stream = new StreamReader(FilePath);
        var serializer = new XmlSerializer(typeof(List<T>), xRoot);
        var results = await Task.Run(() => (List<T>)serializer.Deserialize(stream));
        return results;
    }
}