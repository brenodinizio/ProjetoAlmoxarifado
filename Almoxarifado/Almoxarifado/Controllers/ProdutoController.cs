using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Almoxarifado.Models;

namespace Almoxarifado.Controllers
{

    public class ProdutoController : Controller
    {
        BDTDSALMOXARIFADO bd = new BDTDSALMOXARIFADO();
        // GET: Produto
        public ActionResult Index()
        {
            //select * from PRODUTO
            return View(bd.PRODUTO.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string descricao, string minimo, string maximo, string estoque)
        {
            PRODUTO novoProduto = new PRODUTO();
            novoProduto.PRODESCRICAO = descricao;
            novoProduto.PROMINIMO = Convert.ToInt32(minimo);
            novoProduto.PROMAXIMO = Convert.ToInt32(maximo);
            novoProduto.PROESTOQUE = Convert.ToInt32(estoque);

            bd.PRODUTO.Add(novoProduto);
            bd.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            PRODUTO produtolocalizar = bd.PRODUTO.ToList().Where(x => x.PROID==id).First();
            return View(produtolocalizar);
        }

        [HttpPost]
        public ActionResult Edit(int? id,string descricao, string minimo, string maximo, string estoque)
        {
            PRODUTO upProduto = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            upProduto.PRODESCRICAO = descricao;
            upProduto.PROMINIMO = Convert.ToInt32(minimo);
            upProduto.PROMAXIMO = Convert.ToInt32(maximo);
            upProduto.PROESTOQUE = Convert.ToInt32(estoque);

            bd.Entry(upProduto).State = EntityState.Modified;
            bd.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            PRODUTO deletProduto = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            return View(deletProduto);
        }

        [HttpPost]
        public ActionResult DeleteConfirma(int? id)
        {
            PRODUTO deletProduto = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            bd.PRODUTO.Remove(deletProduto);

            try
            {
                bd.SaveChanges();
            }
            catch (Exception e)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View();
        }
    }
    
}