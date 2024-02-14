namespace BancoAPI.Filters.Exceptions
{
    public class SaldoInconsistenteException : Exception
    {
        public SaldoInconsistenteException(string message) : base(message) { }
    }
}
