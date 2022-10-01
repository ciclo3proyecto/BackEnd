using System.Net;

namespace InventoryApp.Api.Infraestructure.Result
{
    public class CommandResult<TData>
    {
        public TData Data { get; set; }

        public string Error { get; set; }

        public bool Success => this.Error == null;

        public bool Failure => this.Error != null;

        public int? Code { get; }


        protected CommandResult() { }

        protected CommandResult(TData data)
        {
            this.Data = data;
        }

        protected CommandResult(string error)
        {
            this.Error = error;
            this.Code = (int)HttpStatusCode.InternalServerError;
        }

        protected CommandResult(string error, int code)
        {
            this.Error = error;
            this.Code = code;
        }

        public static CommandResult<TData> Ok() => new CommandResult<TData>();

        public static CommandResult<TData> Ok(TData data) => new CommandResult<TData>(data);

        public static CommandResult<TData> Fail(string error) => new CommandResult<TData>(error);

        public static CommandResult<TData> Fail(string error, int code) => new CommandResult<TData>(error, code);

    }
}
