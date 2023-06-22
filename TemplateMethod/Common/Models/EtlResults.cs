namespace TemplateMethod.Common.Models
{
    public class EtlResults
    {
        public string Status { get; set; } = "Failed";
        public string Error { get; set; } = "";
        public TimeSpan Time { get; set; } = TimeSpan.FromSeconds(0);
        public int RowCount { get; set; } = 0;
    }
}
