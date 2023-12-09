using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Services.Interface
{
    public interface ITransacaoService
    {

        List<TransacaoModel> ListarTransacoes();
        TransacaoModel RetornarRegistro(int? id);
        void Salvar(TransacaoModel model);
        void Excluir(int id);
    }
}
