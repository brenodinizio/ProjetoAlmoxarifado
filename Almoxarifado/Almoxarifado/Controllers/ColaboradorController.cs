using Almoxarifado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almoxarifado.Controllers
{
    public class ColaboradorController : Controller
    {
        BDTDSALMOXARIFADO bd = new BDTDSALMOXARIFADO();
        // GET: Colaborador
        public ActionResult Index()
        {
            return View(bd.COLABORADOR.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listaArea = bd.AREA.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nome, string cargo, int? codigoarea)
        {
            COLABORADOR colaborador = new COLABORADOR();
            colaborador.COLNOME = nome;
            colaborador.COLCARGO = cargo;
            colaborador.AREID = codigoarea;

            try
            {
                bd.COLABORADOR.Add(colaborador);
                bd.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorBD", "Home");
            }

            return RedirectToAction("Index");
        }
    }
}