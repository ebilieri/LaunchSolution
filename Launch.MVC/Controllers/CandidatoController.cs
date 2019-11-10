using Launch.Domain.Entidades;
using Launch.Domain.Services;
using Launch.MVC.AutoMapperConfig;
using Launch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Launch.MVC.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Cadastrar");
        }


        public IActionResult Cadastrar()
        {
            var model = new CandidatoModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastrar(CandidatoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                // Mapping Model to Candidato
                var obj = model.MapTo<Candidato>();

                _candidatoService.Adicionar(obj);

                model.Id = obj.Id;
                model.MensagemValidacao = obj.MensagemValidacao;

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
            catch (Exception ex)
            {
                string message = string.Format("Atenção: {0}", ex.Message);
                ModelState.AddModelError(string.Empty, message);
            }

            return View(model);
        }
    }
}
