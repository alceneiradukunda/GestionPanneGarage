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
    public class CategoriesArticlesController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();

        //
        // GET: /CategoriesArticles/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.CategoriesArticles.ToList());
        }

        //
        // GET: /CategoriesArticles/Details/5

        public ActionResult Details(int id = 0)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            if (categoriesarticle == null)
            {
                return HttpNotFound();
            }
            return View(categoriesarticle);
        }

        //
        // GET: /CategoriesArticles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoriesArticles/Create

        [HttpPost]
        public ActionResult Create(CategoriesArticle categoriesarticle)
        {
            if (ModelState.IsValid)
            {
                db.CategoriesArticles.Add(categoriesarticle);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index");
            }

            return View(categoriesarticle);
        }

        //
        // GET: /CategoriesArticles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            if (categoriesarticle == null)
            {
                return HttpNotFound();
            }
            return View(categoriesarticle);
        }

        //
        // POST: /CategoriesArticles/Edit/5

        [HttpPost]
        public ActionResult Edit(CategoriesArticle categoriesarticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriesarticle).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index");
            }
            return View(categoriesarticle);
        }

        //
        // GET: /CategoriesArticles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            if (categoriesarticle == null)
            {
                return HttpNotFound();
            }
            return View(categoriesarticle);
        }

        //
        // POST: /CategoriesArticles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            db.CategoriesArticles.Remove(categoriesarticle);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        //Mecanicien

        public ActionResult Index1()
        {
            return View(db.CategoriesArticles.ToList());
        }

        //
        // GET: /CategoriesArticles/Details/5

        public ActionResult Details1(int id = 0)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            if (categoriesarticle == null)
            {
                return HttpNotFound();
            }
            return View(categoriesarticle);
        }

        //
        // GET: /CategoriesArticles/Create

        public ActionResult Create1()
        {
            return View();
        }

        //
        // POST: /CategoriesArticles/Create

        [HttpPost]
        public ActionResult Create1(CategoriesArticle categoriesarticle)
        {
            if (ModelState.IsValid)
            {
                db.CategoriesArticles.Add(categoriesarticle);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index1");
            }

            return View(categoriesarticle);
        }

        //
        // GET: /CategoriesArticles/Edit/5

        public ActionResult Edit1(int id = 0)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            if (categoriesarticle == null)
            {
                return HttpNotFound();
            }
            return View(categoriesarticle);
        }

        //
        // POST: /CategoriesArticles/Edit/5

        [HttpPost]
        public ActionResult Edit1(CategoriesArticle categoriesarticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriesarticle).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index1");
            }
            return View(categoriesarticle);
        }

        //
        // GET: /CategoriesArticles/Delete/5

        public ActionResult Delete1(int id = 0)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            if (categoriesarticle == null)
            {
                return HttpNotFound();
            }
            return View(categoriesarticle);
        }

        //
        // POST: /CategoriesArticles/Delete/5

        [HttpPost, ActionName("Delete1")]
        public ActionResult DeleteConfirmed1(int id)
        {
            CategoriesArticle categoriesarticle = db.CategoriesArticles.Find(id);
            db.CategoriesArticles.Remove(categoriesarticle);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
          
            return RedirectToAction("Index1");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}