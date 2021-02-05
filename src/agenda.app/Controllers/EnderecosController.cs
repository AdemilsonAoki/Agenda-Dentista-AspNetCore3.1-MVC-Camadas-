/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agenda.app.Data;
using agenda.app.ViewModels;

namespace agenda.app.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnderecosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enderecos
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnderecoViewModel.ToListAsync());
        }

        // GET: Enderecos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoViewModel = await _context.EnderecoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoViewModel == null)
            {
                return NotFound();
            }

            return View(enderecoViewModel);
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Logradouro,Numero,Complemento,Bairro,Cep,Cidade,Estado,ClienteId")] EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                enderecoViewModel.Id = Guid.NewGuid();
                _context.Add(enderecoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoViewModel);
        }

        // GET: Enderecos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoViewModel = await _context.EnderecoViewModel.FindAsync(id);
            if (enderecoViewModel == null)
            {
                return NotFound();
            }
            return View(enderecoViewModel);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Logradouro,Numero,Complemento,Bairro,Cep,Cidade,Estado,ClienteId")] EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoViewModelExists(enderecoViewModel.Id))
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
            return View(enderecoViewModel);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoViewModel = await _context.EnderecoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoViewModel == null)
            {
                return NotFound();
            }

            return View(enderecoViewModel);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var enderecoViewModel = await _context.EnderecoViewModel.FindAsync(id);
            _context.EnderecoViewModel.Remove(enderecoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoViewModelExists(Guid id)
        {
            return _context.EnderecoViewModel.Any(e => e.Id == id);
        }
    }
}*/
