using System.Net;
using System.Text.Json;

namespace InventoryApp.Api.Infraestructure.Result
{
    public class ExceptionResult
    {
        public string Type { get; set; }

        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public ExceptionDetails Errors { get; set; }

        public ExceptionResult()
        {

        }

        public ExceptionResult(int status, string message, string traceId)
        {
            this.Status = status;
            this.TraceId = traceId;
            this.Errors = new ExceptionDetails { Message = new List<string> { message } };
            this.setDependentProperties();
        }

        private void setDependentProperties()
        {
            switch (this.Status)
            {
                case (int)HttpStatusCode.BadRequest:
                    Title = "Bad request";
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                    break;
                case (int)HttpStatusCode.Forbidden:
                    Title = "Forbidden";
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3";
                    break;
                case (int)HttpStatusCode.InternalServerError:
                    Title = "Internal server error";
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                    break;
                default:
                    Title = "Other error.";
                    break;
            }
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
