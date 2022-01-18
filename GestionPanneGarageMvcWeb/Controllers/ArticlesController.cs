using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionPanneGarageMvcWeb.Models;

namespace GestionPanneGarageMvcWeb.Controllers
{
    public class ArticlesController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();


        //
        // GET: /Articles/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            var articles = db.Articles.Include(a => a.CategoriesArticle).Include(a => a.TypesVehicule);
            return View(articles.ToList());
        }

        //
        // GET: /Articles/Details/5

        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Articles/Create

        public ActionResult Create()
        {
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle");
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules");
            return View();
        }

        //
        // POST: /Articles/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index");
            }

            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategories", article.CategoriesArticlesId);
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules", article.TypesVehiculesId);
            return View(article);
        }

        //
        // GET: /Articles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle", article.CategoriesArticlesId);
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules", article.TypesVehiculesId);
            return View(article);
        }

        //
        // POST: /Articles/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle", article.CategoriesArticlesId);
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules", article.TypesVehiculesId);
            return View(article);
        }

        //
        // GET: /Articles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Articles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('La modification reusie avec succes');</script>";
            return RedirectToAction("Index");
        }
        //Mecanicien
        public ActionResult Index1()
        {
            ViewBag.msg = TempData["msg"] as string;
            var articles = db.Articles.Include(a => a.CategoriesArticle).Include(a => a.TypesVehicule);
            return View(articles.ToList());
        }

        //
        // GET: /Articles/Details/5

        public ActionResult Details1(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Articles/Create

        public ActionResult Create1()
        {
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle");
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules");
            return View();
        }

        //
        // POST: /Articles/Create

        [HttpPost]
        public ActionResult Create1(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index1");
            }

            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategories", article.CategoriesArticlesId);
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules", article.TypesVehiculesId);
            return View(article);
        }

        //
        // GET: /Articles/Edit/5

        public ActionResult Edit1(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle", article.CategoriesArticlesId);
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules", article.TypesVehiculesId);
            return View(article);
        }

        //
        // POST: /Articles/Edit/5

        [HttpPost]
        public ActionResult Edit1(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index1");
            }
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle", article.CategoriesArticlesId);
            ViewBag.TypesVehiculesId = new SelectList(db.TypesVehicules, "Id", "DescriptionsVehicules", article.TypesVehiculesId);
            return View(article);
        }

        //
        // GET: /Articles/Delete/5

        public ActionResult Delete1(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Articles/Delete/5

        [HttpPost, ActionName("Delete1")]
        public ActionResult DeleteConfirmed1(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            return RedirectToAction("Index1");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}