using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services.Interface;

namespace myfinance_web_dotnet.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _financeDbContext;

        public TransacaoService(MyFinanceDbContext _financeDbContext)
        {
            this._financeDbContext = _financeDbContext;
        }

        public List<TransacaoModel> ListarTransacoes()
        {
            return _financeDbContext.Transacao.Where(p => p.Ativo == true).ToList();
        }

        public TransacaoModel RetornarRegistro(int? id)
        {
            return _financeDbContext.Transacao.FirstOrDefault(p => p.Id == id);
        }

        public void Salvar(TransacaoModel model)
        {
            if (model.Id == 0)
            {
                model.Data = DateTime.Now;
                model.Ativo = true;
                _financeDbContext.Transacao.Add(model);
            }
            else
            {
                _financeDbContext.Transacao.Attach(model);
                _financeDbContext.Entry(model).State = EntityState.Modified;
            }
            _financeDbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var item = _financeDbContext.Transacao.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                item.Ativo = false;
            }

            _financeDbContext.SaveChanges();
        }

    }
}
