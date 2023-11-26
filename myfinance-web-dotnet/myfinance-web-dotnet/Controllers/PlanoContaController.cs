using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services.Interface;
using System.Diagnostics;

namespace myfinance_web_dotnet.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlanoContaService _planoContaService;
        private readonly IMapper _mapper;

        public PlanoContaController(ILogger<HomeController> logger, IPlanoContaService _planoContaService, IMapper _mapper)
        {
            this._logger = logger;
            this._planoContaService = _planoContaService;
            this._mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<PlanoContaViewModel>>(_planoContaService.ListarPlanoContas()));
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            if(id != null)
            {
                return View(_mapper.Map<PlanoContaViewModel>(_planoContaService.RetornarRegistro(id)));
            }

            return View(new PlanoContaViewModel());
        }


        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(PlanoContaViewModel planoContaViewModel)
        {
            _planoContaService.Salvar(_mapper.Map<PlanoContaModel>(planoContaViewModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _planoContaService.Excluir(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
