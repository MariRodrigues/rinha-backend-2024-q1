namespace BancoAPI.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public int Valor { get; set; }
        public char Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Realizada_Em { get; set; }

        public Transacao() { }

        public Transacao(int clientId, int valor, char tipo, string descricao)
        {
            ClienteId = clientId;
            Valor = valor;
            Tipo = tipo;
            Descricao = descricao;
            Realizada_Em = DateTime.Now;
        }
    }
}
