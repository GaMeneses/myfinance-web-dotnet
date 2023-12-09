using myfinance_web_dotnet.Enumerations;

namespace myfinance_web_dotnet.Domain
{
    public class PlanoContaModel
    {      
        public int Id { get; set; }
        public string Descricao { get; set; }
        public TipoConta Tipo { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<TransacaoModel> Transacoes { get; set; } = new List<TransacaoModel>();
    }
}
