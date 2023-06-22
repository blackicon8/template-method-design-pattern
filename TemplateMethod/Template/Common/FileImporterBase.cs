using TemplateMethod.Common.Models;
using TemplateMethod.Common.Services;

namespace TemplateMethod.Template.TemplateBase
{
    public abstract class FileImporterBase
    {
        public string BaseDirectory { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        private string _filePath;
        internal string FilePath
        {
            get { return _filePath; }
            set
            {
                if (Path.IsPathRooted(_filePath))
                {
                    _filePath = value;
                }
                else
                {
                    _filePath = Path.Combine(BaseDirectory, value);
                }; 
            }
        }

        // Template method
        public async Task ImportAsync<T>(string filePath) where T : class
        {
            FilePath = filePath;

            var etlResults = await ETLAsync<T>();
            Report(etlResults);
        }

        // Base operations
        private void Report(EtlResults reportDetails)
        {
            ContextConsole.WriteReport(FilePath, reportDetails);
        }

        // Customizable operations
        protected abstract Task<IList<T>> ExtractAsync<T>();

        // Optional operations
        protected virtual void Load<T>(IList<T> data) where T : class
        {
            var repository = new Repository<T>();
            repository.AddRange(data);
        }

        protected virtual bool IsValid<T>(IList<T> data)
        {
            return true;
        }

        protected virtual IList<T> Transform<T>(IList<T> data)
        {
            return data;
        }

        private async Task<EtlResults> ETLAsync<T>() where T : class
        {
            var etlResults = new EtlResults();

            try
            {
                etlResults.Time = await StopWatchUtil.TimeAsync(async () =>
                {
                    var rawData = await ExtractAsync<T>();

                    if (!IsValid(rawData))
                    {
                        etlResults.Status = "Invalid";
                        return;
                    }

                    var transformedData = Transform(rawData);
                    Load(transformedData);

                    etlResults.Status = "Succeeded";
                    etlResults.RowCount = transformedData.Count;
                });
            }
            catch (Exception ex)
            {
                etlResults.Error = ex.Message;
            }

            return etlResults;
        }
    }
}