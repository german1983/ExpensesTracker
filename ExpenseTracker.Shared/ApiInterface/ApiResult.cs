using System.Linq;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Shared.ApiInterface
{
    public class ApiResult<T>
    {
        public T Data { get; set; }
        public ApiError[] ApiErrors { get; set; }
        public ApiWarning[] ApiWarnings { get; set; }

        [JsonIgnore]
        public bool IsSuccessful => (!ApiErrors?.Any() ?? true) && Data != null;
    }

    public class ApiError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class ApiWarning
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
