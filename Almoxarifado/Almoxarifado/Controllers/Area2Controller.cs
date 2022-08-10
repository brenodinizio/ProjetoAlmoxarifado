using Almoxarifado.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almoxarifado.Controllers
{
    
    public class Area2Controller : Controller
    {
        BDTDSALMOXARIFADO bd = new BDTDSALMOXARIFADO();
        // GET: Area2
        public ActionResult Index()
        {
            return View(bd.AREA.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string descricao)
        {
            AREA novoArea = new AREA();
            novoArea.AREDESCRICAO= descricao;
            bd.AREA.Add(novoArea);
      

            try
            {
                bd.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorBD", "Home");
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            AREA exibirArea = bd.AREA.ToList().Where(y => y.AREID == id).First();
            return View (exibirArea);
        }

        [HttpPost]
        public ActionResult Editar(int id,string descricao)
        {
            AREA updateArea = bd.AREA.ToList().Where(y => y.AREID == id).First();
            updateArea.AREDESCRICAO= descricao;
            bd.Entry(updateArea).State = EntityState.Modified;

            try
            {
                bd.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorBD", "Home");

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            AREA exibirArea = bd.AREA.ToList().Where(y => y.AREID == id).First();
            return View(exibirArea);
        }

        [HttpPost]
        public ActionResult ExcluirConfirmar(int id)
        {
            AREA excluirArea = bd.AREA.ToList().Where(y => y.AREID == id).First();
            bd.AREA.Remove(excluirArea);

            try
            {
                bd.SaveChanges();
            }
            catch (Exception)
            {
                Mensagem.textoErro = "Não é possível excluir, campo já relacionado a outra tabela";
                return RedirectToAction("ErrorBD", "Home");
            }
            return RedirectToAction("Index");
        }



    }
}