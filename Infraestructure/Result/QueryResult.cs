using System.Net;

namespace InventoryApp.Api.Infraestructure.Result
{
    public class QueryResult<TData>
    {
        public TData Data { get; set; }

        public string Error { get; set; }

        public bool Success => this.Error == null;

        public bool Failure => this.Error != null;

        public int? Code { get; }


        protected QueryResult() { }

        protected QueryResult(TData data)
        {
            this.Data = data;
        }

        protected QueryResult(string error)
        {
            this.Error = error;
            this.Code = (int)HttpStatusCode.InternalServerError;
        }

        protected QueryResult(string error, int code)
        {
            this.Error = error;
            this.Code = code;
        }

        public static QueryResult<TData> Ok() => new QueryResult<TData>();

        public static QueryResult<TData> Ok(TData data) => new QueryResult<TData>(data);

        public static QueryResult<TData> Fail(string error) => new QueryResult<TData>(error);

        public static QueryResult<TData> Fail(string error, int code) => new QueryResult<TData>(error, code);

    }
}
