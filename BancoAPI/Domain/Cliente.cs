namespace BancoAPI.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Limite { get; set; }
        public int Saldo { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }

        public Cliente(int limite, int saldo)
        {
            Limite = limite;
            Saldo = saldo;
        }
        
        public Cliente() { }
    }
}
