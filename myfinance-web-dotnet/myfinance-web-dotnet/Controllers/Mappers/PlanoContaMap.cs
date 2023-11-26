using AutoMapper;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers.Mappers
{
    public class PlanoContaMap : Profile
    {
        public PlanoContaMap()
        {
            CreateMap<PlanoContaModel, PlanoContaViewModel>().ReverseMap();
        }
    }
}
