using System;

namespace InventoryApp.Api.Infraestructure.Exceptions
{
    public class AppException : Exception
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public int StatusCode { get; }

        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, Exception inner) : base(message, inner) { }

        public AppException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
