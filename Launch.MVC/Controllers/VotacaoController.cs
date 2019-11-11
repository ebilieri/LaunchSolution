using Launch.Domain.Contratos.IServices;
using Launch.Domain.Entidades;
using Launch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Launch.MVC.Controllers
{
    public class VotacaoController :Controller
    {
        private readonly IVotacaoService _votacaoService;

        public VotacaoController(IVotacaoService votacaoService)
        {
            _votacaoService = votacaoService;
        }

        public IActionResult Votar(int id)
        {
            try
            {
                var model = new Votacao() { CandidatoId = id};

                _votacaoService.Adicionar(model);

                if (model.Id > 0)
                {
                    return RedirectToAction("index", "home");
                }
                else if (model.MensagemValidacao != null && model.MensagemValidacao.Count > 0)
                {
                    foreach (var item in model.MensagemValidacao)
                    {
                        string message = string.Format("Atenção: {0}", item);
                        ModelState.AddModelError(string.Empty, message);
                    }                    
                }
            }
            catch(Exception ex)
            {
                string message = string.Format("Atenção: {0}", ex.Message);
                ModelState.AddModelError(string.Empty, message);               
            }

            return RedirectToAction("index", "home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
