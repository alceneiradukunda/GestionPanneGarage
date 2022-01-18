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
    public class UsersController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();
        //
        // GET: /Users/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            var users = db.Users.Include(u => u.Profile);
            return View(users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

       
            //
        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "ProfileName");
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "ProfileName", user.ProfileId);
            return View(user);
        }
        //login
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User userr)
        {
            var v = from p in db.Profiles
                    join u in db.Users
                        on p.Id equals u.ProfileId
                    where (u.Username == userr.Username && u.Password == userr.Password)
                    select new
                    {
                        profile_name = p.ProfileName,
                        username = u.Username,
                        password=u.Password,
                        telephone=u.Telephone,
                        email=u.Email
                    };

            var result = v.FirstOrDefault();

            if (result != null)
            {
                Session["username"] = result.username;
                Session["password"] = result.password;
                Session["telephone"] = result.telephone;
                Session["email"] = result.email;
                if (result.profile_name == "Admin")
                {
                    TempData["mssg"] = "Vous venez se authentifier avec Succes";
                    return RedirectToAction("Listes_Clients_leurs_Vehicules", "Reparations");
                }
                else if (result.profile_name == "User")
                {
                    TempData["mssg"] = "Vous venez de se authentifier avec Succes";
                    return RedirectToAction("Listesdesclientsetleursvehicules", "Reparations");
                }
                else if (result.profile_name != "Admin" && result.profile_name != "User")
                {
                    TempData["mssg"] = "Impossible de se authentifier";

                    return RedirectToAction("Login", "Users");
                }

            }
            return View(userr);
           
        }
        //lOGOUT
        public ActionResult Logout( )
        {
            Session.Clear();
            Session["username"] = null;
            Session["password"] = null;
            Session["telephone"] = null;
            return RedirectToAction("Login", "Users");
        }
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "ProfileName", user.ProfileId);
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index");
            }
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "ProfileName", user.ProfileId);
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}