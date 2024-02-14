namespace BancoAPI.Domain.ViewModels
{
    public class ExtratoViewModel
    {
        public Saldo Saldo { get; set; }
        public List<Transacoes> Ultimas_transacoes { get; set; }

    }

    public class Saldo
    {
        public int Total { get; set; }
        public DateTime Data_extrato { get; set; }
        public int Limite { get; set; }
    }

    public class  Transacoes
    {
        public int Valor { get; set; }
        public char Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Realizada_em { get; set; }
    }
}
