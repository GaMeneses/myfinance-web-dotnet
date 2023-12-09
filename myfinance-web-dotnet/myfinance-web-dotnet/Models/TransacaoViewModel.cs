using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Enumerations;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoViewModel
    {
        public int Id { get; set; }
        public string? Historico { get; set; }
        public string? Tipo { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public int PlanoContaId { get; set; }
        public bool Ativo { get; set; }
        public List<PlanoContaViewModel> PlanosConta { get; set; }

        public List<SelectListItem> TiposPlanoConta
        {
            get
            {
                return PlanosConta
                            .Select(t => new SelectListItem
                            {
                                Value = t.Id.ToString(),
                                Text = t.Descricao
                            })
                            .ToList();

            }
        
        }
    }
}
