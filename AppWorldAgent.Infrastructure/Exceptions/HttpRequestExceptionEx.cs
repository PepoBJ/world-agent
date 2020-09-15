namespace AppWorldAgent.Infrastructure.Exceptions
{
    using System;
    using System.Net.Http;

    public class HttpRequestExceptionEx : HttpRequestException
    {
        public System.Net.HttpStatusCode HttpCode { get; }
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code) : this(code, null, null){}

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string content) : this(code, content, null){}

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            HttpCode = code;
        }
    }
}
