using myfinance_web_dotnet.Enumerations;

namespace myfinance_web_dotnet.Domain
{
    public class PlanoContaModel
    {      
        public int Id { get; set; }
        public string Descricao { get; set; }
        public TipoConta Tipo { get; set; }
    }
}
