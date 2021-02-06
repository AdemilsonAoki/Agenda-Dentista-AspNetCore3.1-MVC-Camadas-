using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agenda.app.Data;
using agenda.app.ViewModels;
using agenda.Business.Interfaces;
using AutoMapper;
using agenda.Business.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace agenda.app.Controllers
{
    public class DentistasController : Controller
    {
        private readonly IDentistaRepository _dentistaRepository;
        private readonly IMapper _mapper;


        public DentistasController(IDentistaRepository dentistaRepository, IMapper mapper)
        {
            _dentistaRepository = dentistaRepository;
            _mapper = mapper;
        }

        // GET: Dentistas
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<DentistaViewModel>>(await _dentistaRepository.ObterTodos()));
        }

        // GET: Dentistas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var dentistaViewModel = await ObterDentistaConsulta(id);
            ;
            if (dentistaViewModel == null)
            {
                return NotFound();
            }

            return View(dentistaViewModel);
        }

        // GET: Dentistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dentistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DentistaViewModel dentistaViewModel)
        {
            if (!ModelState.IsValid) return View(dentistaViewModel);

            var imgPrefix = Guid.NewGuid() + "_";

            if (!await UploadArquivo(dentistaViewModel.ImagemUPload, imgPrefix))
            {
                return View(dentistaViewModel);
            }
            dentistaViewModel.Imagem = imgPrefix + dentistaViewModel.ImagemUPload.FileName;
            var dentista = _mapper.Map<Dentista>(dentistaViewModel);
            await _dentistaRepository.Adicionar(dentista);

            return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Dentistas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var dentistaViewModel = await ObterDentistaConsulta(id);
            if (dentistaViewModel == null)
            {
                return NotFound();
            }
            return View(dentistaViewModel);
        }

        // POST: Dentistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DentistaViewModel dentistaViewModel)
        {

            if (id != dentistaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid) return View(dentistaViewModel);
            var dentista = _mapper.Map<Dentista>(dentistaViewModel);
            await _dentistaRepository.Atualizar(dentista);

            return RedirectToAction(nameof(Index));
        }

        // GET: Dentistas/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            var dentistaViewModel = await ObterDentista(id);
             if (dentistaViewModel == null)
            {
                return NotFound();
            }

            return View(dentistaViewModel);
        }

        // POST: Dentistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dentistaViewModel = await ObterDentista(id);

            if (dentistaViewModel == null) return NotFound();

            await _dentistaRepository.Remover(id);
      
            return RedirectToAction(nameof(Index));
        }

     

        private async Task<DentistaViewModel> ObterDentistaConsulta(Guid id)
        {
            return _mapper.Map<DentistaViewModel>(await _dentistaRepository.ObterDentistaConsulta(id));

        }

         
        private async Task<DentistaViewModel> ObterDentista(Guid id)
        {
            return _mapper.Map<DentistaViewModel>(await _dentistaRepository.ObterDentista(id));

        }

        private async Task<bool>UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome!!");
                return false;
            }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }
            return true;

        }
    }

}
