using HyperAutomation.ControlRoom.Shared.Models;
using System.Collections.Generic;
using System.Net;

namespace HyperAutomation.ControlRoom.Shared.ApiClient.Models
{
    public class ApiClientResult<T> : BaseResult<T>
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ApiUrlBase { get; set; }
        public string ApiRoute { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsException { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public bool Unauthorized => StatusCode == HttpStatusCode.Unauthorized;
    }
}
