using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using agenda.app.ViewModels;
using agenda.Business.Interfaces;
using AutoMapper;
using agenda.Business.Models;

namespace agenda.app.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly IMapper _mapper;


        public ClientesController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var clienteViewModel = await ObterConsultaPorClienteEndereco(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {


            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Adicionar(cliente);

            return RedirectToAction(nameof(Index));

        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var clienteViewModel = await ObterConsultaPorClienteEndereco(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(clienteViewModel);
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));

        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var clienteViewModel = await ObterClienteEndereco(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clienteViewModel = await  ObterClienteEndereco(id);

            if (clienteViewModel == null) return NotFound();

            await _clienteRepository.Remover(id);
            return RedirectToAction(nameof(Index));
        }


        private async Task<ClienteViewModel> ObterConsultaPorClienteEndereco(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterConsultaPorClienteEndereco(id));

        }

        private async Task<ClienteViewModel> ObterClienteEndereco(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClienteEndereco(id));

        }
    }
}
