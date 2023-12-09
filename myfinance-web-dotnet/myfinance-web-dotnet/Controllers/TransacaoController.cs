using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;
using myfinance_web_dotnet.Services.Interface;
using System.Diagnostics;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;
        private readonly IMapper _mapper;

        public TransacaoController(ILogger<HomeController> logger,
            ITransacaoService _transacaoService,
            IPlanoContaService _planoContaService,
            IMapper _mapper)
        {
            this._logger = logger;
            this._transacaoService = _transacaoService;
            this._planoContaService = _planoContaService;
            this._mapper = _mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View(_mapper.Map<List<TransacaoViewModel>>(_transacaoService.ListarTransacoes()));
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            if (id != null)
            {
                var model = new TransacaoViewModel();

                model = _mapper.Map<TransacaoViewModel>(_transacaoService.RetornarRegistro(id));
                model.PlanosConta = _mapper.Map<List<PlanoContaViewModel>>(_planoContaService.ListarPlanoContas());

                return View(model);
                //return View(_mapper.Map<TransacaoViewModel>(_transacaoService.RetornarRegistro(id)));
            }

            return View(new TransacaoViewModel { PlanosConta = _mapper.Map<List<PlanoContaViewModel>>(_planoContaService.ListarPlanoContas()) });
        }


        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(TransacaoViewModel model)
        {
            _transacaoService.Salvar(_mapper.Map<TransacaoModel>(model));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _transacaoService.Excluir(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
