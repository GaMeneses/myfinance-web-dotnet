using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Services.Interface
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> ListarPlanoContas();
        void Salvar(PlanoContaModel model);
        PlanoContaModel RetornarRegistro(int? id);
        void Excluir(int id);
    }
}
