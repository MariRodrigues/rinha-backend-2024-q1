namespace BancoAPI.Response
{
    public class TransacaoResponse
    {
        public int Limite { get; set; }
        public int Saldo { get; set; }

        public TransacaoResponse(int limite, int saldo)
        {
            Limite = limite;
            Saldo = saldo;
        }
    }
}
