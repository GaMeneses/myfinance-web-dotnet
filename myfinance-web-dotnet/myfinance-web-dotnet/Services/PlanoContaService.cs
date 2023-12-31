﻿using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services.Interface;

namespace myfinance_web_dotnet.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _financeDbContext;
        public PlanoContaService(MyFinanceDbContext _financeDbContext)
        {
            this._financeDbContext = _financeDbContext;
        }

        public void Excluir(int id)
        {
            var item = _financeDbContext.PlanoConta.FirstOrDefault(p => p.Id == id);

            if(item != null)
            {
                item.Ativo = false;
                _financeDbContext.SaveChanges();
            }

        }

        public List<PlanoContaModel> ListarPlanoContas()
        {
            return _financeDbContext.PlanoConta.Where(p => p.Ativo == true).ToList();
        }

        public PlanoContaModel RetornarRegistro(int? id)
        {
            return _financeDbContext.PlanoConta.FirstOrDefault(p => p.Id == id);
        }

        public void Salvar(PlanoContaModel model)
        {
            if (model.Id == 0)
            {
                model.Ativo = true;
                _financeDbContext.PlanoConta.Add(model);
            }
            else
            {
                _financeDbContext.PlanoConta.Attach(model);
                _financeDbContext.Entry(model).State = EntityState.Modified;
            }
            _financeDbContext.SaveChanges();
        }
    }
}
