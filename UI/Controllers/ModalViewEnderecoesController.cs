using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Applicationcore.Entities;
using Infra.Data;

namespace UI.Controllers
{
    public class ModalViewEnderecoesController : Controller
    {
        private readonly ContextDB _context;

        public ModalViewEnderecoesController(ContextDB context)
        {
            _context = context;
        }

        // GET: ModalViewEnderecoes
        public async Task<IActionResult> Index()
        {
            var contextDB = _context.ModalViewEnderecos.Include(m => m.Client);
            return View(await contextDB.ToListAsync());
        }

        // GET: ModalViewEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalViewEndereco = await _context.ModalViewEnderecos
                .Include(m => m.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalViewEndereco == null)
            {
                return NotFound();
            }

            return View(modalViewEndereco);
        }

        // GET: ModalViewEnderecoes/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "gender");
            return View();
        }

        // POST: ModalViewEnderecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,street,number,complement,neightborhood,city,state,numero,Id")] ModalViewEndereco modalViewEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalViewEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "gender", modalViewEndereco.ClientId);
            return View(modalViewEndereco);
        }

        // GET: ModalViewEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalViewEndereco = await _context.ModalViewEnderecos.FindAsync(id);
            if (modalViewEndereco == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "gender", modalViewEndereco.ClientId);
            return View(modalViewEndereco);
        }

        // POST: ModalViewEnderecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,street,number,complement,neightborhood,city,state,numero,Id")] ModalViewEndereco modalViewEndereco)
        {
            if (id != modalViewEndereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalViewEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalViewEnderecoExists(modalViewEndereco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "gender", modalViewEndereco.ClientId);
            return View(modalViewEndereco);
        }

        // GET: ModalViewEnderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalViewEndereco = await _context.ModalViewEnderecos
                .Include(m => m.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalViewEndereco == null)
            {
                return NotFound();
            }

            return View(modalViewEndereco);
        }

        // POST: ModalViewEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalViewEndereco = await _context.ModalViewEnderecos.FindAsync(id);
            _context.ModalViewEnderecos.Remove(modalViewEndereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalViewEnderecoExists(int id)
        {
            return _context.ModalViewEnderecos.Any(e => e.Id == id);
        }
    }
}
