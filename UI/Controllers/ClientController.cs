using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Applicationcore.Entities;
using Applicationcore.Services.IService;
using System;

namespace UI.Controllers
{
    public class ClientController : Controller
    {

        private IServices<Client> _ServicoCliente;
        private IServices<Adress> _ServicoAdress;

        public ClientController(IServices<Client> ServicoCliente, IServices<Adress> ServicoAdress)
        {
            _ServicoCliente = ServicoCliente;
            _ServicoAdress = ServicoAdress;
        }

         public async Task<IActionResult> Index()
        {
             return View(await _ServicoCliente.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ServicoCliente.InsertAsync(client);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var client = await _ServicoCliente.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }


        public async Task<IActionResult> Edit(int id)
        {
           var cliente = await _ServicoCliente.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Client client)
        {
            if (ModelState.IsValid)
            {
                await _ServicoCliente.UpdateAsync(client);
            }
             return RedirectToAction(nameof(Index));
        }

       [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
           var client = await _ServicoCliente.GetByIdAsync(Id);
            if (client == null)
            {
                return NotFound();
            }
              return View(client);
         }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _ServicoCliente.GetByIdAsync(id);
        
            if (client == null)
            {
                return NotFound();
            }
            try
            {
                  await _ServicoCliente.DeleteAsync(client);
            }
            catch (InvalidCastException e)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }

}







