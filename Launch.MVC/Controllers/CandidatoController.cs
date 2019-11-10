using Launch.Domain.Services;
using Launch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            try {
               // _candidatoService.Adicionar(model);

            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
    }
}
