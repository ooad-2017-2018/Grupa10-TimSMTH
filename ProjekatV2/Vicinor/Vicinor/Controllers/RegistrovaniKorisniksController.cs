using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vicinor.Model;
using Vicinor.Models;

namespace Vicinor.Controllers
{
    public class RegistrovaniKorisniksController : Controller
    {
        private VicinorContext db = new VicinorContext();

        // GET: RegistrovaniKorisniks
        public ActionResult Index()
        {
            return View( db.RegistrovaniKorisnik.ToList());
        }

        // GET: RegistrovaniKorisniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrovaniKorisnik registrovaniKorisnik = db.Korisnik.OfType<RegistrovaniKorisnik>().SingleOrDefault(s => s.KorisnikId == id);
            if (registrovaniKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(registrovaniKorisnik);
        }

        // GET: RegistrovaniKorisniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrovaniKorisniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisnikId,Password,Username,FirstName,LastName,Email,Banned,DateOfBirth,Image")] RegistrovaniKorisnik registrovaniKorisnik)
        {
            if (ModelState.IsValid)
            {
                db.RegistrovaniKorisnik.Add(registrovaniKorisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrovaniKorisnik);
        }

        // GET: RegistrovaniKorisniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrovaniKorisnik registrovaniKorisnik = db.Korisnik.OfType<RegistrovaniKorisnik>().SingleOrDefault(s => s.KorisnikId == id);
            if (registrovaniKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(registrovaniKorisnik);
        }

        // POST: RegistrovaniKorisniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KorisnikId,Password,Username,FirstName,LastName,Email,Banned,DateOfBirth,Image")] RegistrovaniKorisnik registrovaniKorisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrovaniKorisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrovaniKorisnik);
        }

        // GET: RegistrovaniKorisniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrovaniKorisnik registrovaniKorisnik = db.Korisnik.OfType<RegistrovaniKorisnik>().SingleOrDefault(s => s.KorisnikId == id);
            if (registrovaniKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(registrovaniKorisnik);
        }

        // POST: RegistrovaniKorisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrovaniKorisnik registrovaniKorisnik = db.Korisnik.OfType<RegistrovaniKorisnik>().SingleOrDefault(s => s.KorisnikId == id);
            db.RegistrovaniKorisnik.Remove(registrovaniKorisnik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
