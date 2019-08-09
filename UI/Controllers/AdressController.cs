using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Applicationcore.Entities;
using Applicationcore.Services.IService;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;

namespace UI.Controllers
{

    //[Route("api/[controller]")]
    //[ApiController]
    public class AdressController : Controller
    {
        private IServices<Adress> _ServicoAdress;
        private IServices<Client> _ServicoCliente;
        private readonly IConfiguration _configuration;

        public AdressController(IServices<Adress> ServicoAdress, IServices<Client> ServicoCliente, IConfiguration configuration)
        {
            _ServicoAdress = ServicoAdress;
            _ServicoCliente = ServicoCliente;
            _configuration = configuration;
        }


        public IActionResult Index()
        {
         ViewLista();
         return View();
         }

        public IActionResult ViewLista()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                string _sql = "";
                _sql += @"select c.name, a.* from Client c inner join Adress a on c.Id=a.ClientId order by c.name";
                var retorno = db.Query<ClientViewModel>(_sql, commandType: CommandType.Text).ToList();
                ViewBag.listagem = retorno;
            }
            return View();
        }


        public IActionResult Create()
        {
            Listar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Adress adress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ServicoAdress.InsertAsync(adress);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var adress = await _ServicoAdress.GetByIdAsync(id);
            if (adress == null)
            {
                return NotFound();
            }
            ViewBag.ClientId = adress.ClientId;
            return View(adress);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Adress adress)
        {
            if (ModelState.IsValid)
            {
                 await _ServicoAdress.UpdateAsync(adress);
            }
               return RedirectToAction(nameof(Index));
        }

        public IActionResult Listar()
        {
            var Clients=  _ServicoCliente.Where(p => p.Id > 0).OrderBy(p => p.name).ToDictionary(p => p.Id, p => p.name);
            ViewBag.client = Clients;
            return Ok(Clients);
        }
    }
}
