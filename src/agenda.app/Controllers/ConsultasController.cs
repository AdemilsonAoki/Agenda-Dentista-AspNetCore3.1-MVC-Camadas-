

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

namespace agenda.app.Controllers
{
    public class ConsultasController : BaseController
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IDentistaRepository _dentistaRepository;
        private readonly IMapper _mapper;

        public ConsultasController(IConsultaRepository consultaRepository, IMapper mapper,
            IClienteRepository clienteRepository, IDentistaRepository dentistaRepository)
        {
            _consultaRepository = consultaRepository;
            _clienteRepository = clienteRepository;
            _dentistaRepository = dentistaRepository;
            _mapper = mapper;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
           
            return View(_mapper.Map<IEnumerable<ConsultaViewModel>>(await _consultaRepository.ObterDentistaClienteAgenda()));
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {

            var consultaViewModel = await ObterConsultaDentistaCliente(id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }

            return View(consultaViewModel);
        }

        // GET: Consultas/Create
        public async Task <IActionResult> Create()
        {
            var consultaViewModel = await PopularClientes(new ConsultaViewModel());



        

            return View(consultaViewModel);
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsultaViewModel consultaViewModel)
        {
            consultaViewModel = await PopularClientes(consultaViewModel);

            if (ModelState.IsValid) return View(consultaViewModel);

            _consultaRepository.Adicionar(_mapper.Map<Consulta>(consultaViewModel));

            // ViewData["ClienteId"] = new SelectList(_context.ClienteViewModel, "Id", "Documento", consultaViewModel.ClienteId);
            //ViewData["DentistaId"] = new SelectList(_context.DentistaViewModel, "Id", "Id", consultaViewModel.DentistaId);
            return View(consultaViewModel);
        }
        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var consultaViewModel = await ObterConsultaDentistaCliente(id);
            if (consultaViewModel == null)
            {
                return NotFound();
            }
           
            return View(consultaViewModel);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DentistaId,ClienteId,Descricao")] ConsultaViewModel consultaViewModel)
        {
            if (id != consultaViewModel.Id) return NotFound();
            

            if (!ModelState.IsValid) return View(consultaViewModel);

            await _consultaRepository.Atualizar(_mapper.Map<Consulta>(consultaViewModel));

            return RedirectToAction("Index");
            
             
                
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var consulta = await ObterConsultaDentistaCliente(id);
           
            if(consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consulta = await ObterConsultaDentistaCliente(id);

            if (consulta == null)
            {
                return NotFound();
            }

            await _consultaRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<ConsultaViewModel> ObterConsultaDentistaCliente(Guid id)
        {
            var consulta = _mapper.Map<ConsultaViewModel>(await _consultaRepository.ObterConsultaDentistaCliente(id));
            consulta.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            consulta.Dentistas = _mapper.Map<IEnumerable<DentistaViewModel>>(await _dentistaRepository.ObterTodos());

            return consulta;
        }

        private async Task<ConsultaViewModel> PopularClientes(ConsultaViewModel consulta)
        {
            consulta.Clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
            consulta.Dentistas = _mapper.Map<IEnumerable<DentistaViewModel>>(await _dentistaRepository.ObterTodos());


            return consulta;
        } 
        private async Task<ConsultaViewModel> PopularDentista(ConsultaViewModel consulta)
        {
            consulta.Dentistas = _mapper.Map<IEnumerable<DentistaViewModel>>(await _dentistaRepository.ObterTodos());

            return consulta;
        }
    }
}
