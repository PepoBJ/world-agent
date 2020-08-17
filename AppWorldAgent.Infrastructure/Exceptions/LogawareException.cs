namespace AppWorldAgent.Infrastructure.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class LogawareException : Exception
    {
        public LogawareException()
            : base() { }

        public LogawareException(string message)
            : base(message) { }

        public LogawareException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public LogawareException(string message, Exception innerException)
            : base(message, innerException) { }

        public LogawareException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected LogawareException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
