using AutoMapper;
using Launch.Domain.Contratos.IServices;
using Launch.Domain.Entidades;
using Launch.Domain.Services;
using Launch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Launch.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidatoService _candidatoService;
        private readonly IVotacaoService _votacaoService;

        public HomeController(ICandidatoService candidatoService, IVotacaoService votacaoService)
        {
            _candidatoService = candidatoService;
            _votacaoService = votacaoService;
        }

        public IActionResult Index()
        {
            var homeModel = new HomeModel();
            DateTime inicioVotacao = Convert.ToDateTime($"{ DateTime.Now.Date.ToShortDateString()} 10:00");
            DateTime fimVotacao = Convert.ToDateTime($"{ DateTime.Now.Date.ToShortDateString()} 12:00");
            if (DateTime.Now >= inicioVotacao && DateTime.Now <= fimVotacao)
            {
                var list = Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoModel>>(_candidatoService.ObterTodos());

                foreach (var item in list)
                {
                    item.VotosDiario = _votacaoService.BuscarTotalVotosDiario(item.Id);
                }

                homeModel.ListCandidatos = list;
            }
            else
            {
                var votacaoDiaria = _votacaoService.BuscarReiDoAlmoco();
                if (votacaoDiaria != null)
                {
                    homeModel.CanditatoRei = new CandidatoModel()
                    {
                        Id = votacaoDiaria.CandidatoId,
                        Nome = votacaoDiaria.Candidato.Nome,
                        VotosDiario = votacaoDiaria.TotalVotosDia
                    };
                }
            }

            return View(homeModel);
        }

        public IActionResult Votar(int id)
        {
            return RedirectToAction("Votar", "Votacao", new { Id = id });
            //_candidatoService.
            // return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
