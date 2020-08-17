namespace AppWorldAgent.Infrastructure.Exceptions
{
    public class AuthenticationException : LogawareException
    {
        public AuthenticationException(string messaje) : base(messaje) { }
    }
}
