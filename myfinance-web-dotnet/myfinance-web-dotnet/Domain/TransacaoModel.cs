namespace myfinance_web_dotnet.Domain
{
    public class TransacaoModel
    {
        public int Id { get; set; }
        public string? Historico { get; set;}
        public string? Tipo { get; set;}
        public double Valor { get; set;}
        public int PlanoContaId { get; set;}
        public DateTime Data { get; set;}
        public bool Ativo { get; set;}
        public PlanoContaModel PlanoConta { get; set; }

    }
}
