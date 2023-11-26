using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Enumerations;

namespace myfinance_web_dotnet.Models
{
    public class PlanoContaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public TipoConta Tipo { get; set; }

        public List<SelectListItem> TiposDisponiveis
        {
            get
            {
                return Enum.GetValues(typeof(TipoConta))
                           .Cast<TipoConta>()
                           .Select(t => new SelectListItem
                           {
                               Value = t.ToString(),
                               Text = t.ToString()
                           })
                           .ToList();
            }
        }
    }
}
