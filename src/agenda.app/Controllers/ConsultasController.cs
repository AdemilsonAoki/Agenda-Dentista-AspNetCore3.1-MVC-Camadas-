

using System;
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
    public class ConsultasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConsultaViewModel.Include(c => c.Cliente).Include(c => c.Dentista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaViewModel = await _context.ConsultaViewModel
                .Include(c => c.Cliente)
                .Include(c => c.Dentista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }

            return View(consultaViewModel);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteViewModel, "Id", "Documento");
            ViewData["DentistaId"] = new SelectList(_context.DentistaViewModel, "Id", "Id");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DentistaId,ClienteId,Descricao")] ConsultaViewModel consultaViewModel)
        {
            if (ModelState.IsValid)
            {
                consultaViewModel.Id = Guid.NewGuid();
                _context.Add(consultaViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteViewModel, "Id", "Documento", consultaViewModel.ClienteId);
            ViewData["DentistaId"] = new SelectList(_context.DentistaViewModel, "Id", "Id", consultaViewModel.DentistaId);
            return View(consultaViewModel);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaViewModel = await _context.ConsultaViewModel.FindAsync(id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteViewModel, "Id", "Documento", consultaViewModel.ClienteId);
            ViewData["DentistaId"] = new SelectList(_context.DentistaViewModel, "Id", "Id", consultaViewModel.DentistaId);
            return View(consultaViewModel);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DentistaId,ClienteId,Descricao")] ConsultaViewModel consultaViewModel)
        {
            if (id != consultaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaViewModelExists(consultaViewModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteViewModel, "Id", "Documento", consultaViewModel.ClienteId);
            ViewData["DentistaId"] = new SelectList(_context.DentistaViewModel, "Id", "Id", consultaViewModel.DentistaId);
            return View(consultaViewModel);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaViewModel = await _context.ConsultaViewModel
                .Include(c => c.Cliente)
                .Include(c => c.Dentista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }

            return View(consultaViewModel);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consultaViewModel = await _context.ConsultaViewModel.FindAsync(id);
            _context.ConsultaViewModel.Remove(consultaViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaViewModelExists(Guid id)
        {
            return _context.ConsultaViewModel.Any(e => e.Id == id);
        }
    }
}
