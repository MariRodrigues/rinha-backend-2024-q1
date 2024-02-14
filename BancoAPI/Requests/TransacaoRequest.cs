using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BancoAPI.Requests
{
    public class TransacaoRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public int Valor { get; set; }
        [Required]
        public char Tipo { get; set; }
        [Required]
        [MaxLength(10)]
        public string Descricao { get; set; }
    }
}
