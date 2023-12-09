using AutoMapper;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers.Mappers
{
    public class TransacaoMap : Profile
    {
        public TransacaoMap()
        {
            CreateMap<TransacaoModel, TransacaoViewModel>().ReverseMap();
        }
    }
}
