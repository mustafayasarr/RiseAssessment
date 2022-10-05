using Newtonsoft.Json;
using RiseAssessment.ReportService.Domain.Models.Enums;

namespace RiseAssessment.ReportService.Domain.Models.Results
{
    public class BaseQueueResult<T>
    {
        public Status Status { get; set; }

        public string? JsonObject { get; set; }
        public T? RequestObject
        {
            get => string.IsNullOrEmpty(JsonObject) ? default : JsonConvert.DeserializeObject<T>(JsonObject);
            set => JsonObject = JsonConvert.SerializeObject(value);
        }
    }

}
