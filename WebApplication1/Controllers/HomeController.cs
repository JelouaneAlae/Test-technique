using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult AddCand(string txtNom, string txtPrenom, int txtPhone, string txtNvEd, int txtNbrEx, string txtDE,string fileCv, string txtemail)
        {
            if (ModelState.IsValid)
            {
                using (test_techniqueEntities db = new test_techniqueEntities())
                {
                    candidature C = new candidature();

                    C.email = txtemail;
                    C.nom = txtNom;
                    C.Prenom = txtPrenom;
                    C.phone = txtPhone;
                    C.Niveau_detude = txtNvEd;
                    C.nombre_danne_exp = txtNbrEx;
                    C.Dernier_employeur = txtDE;
                    db.candidatures.Add(C);
                    db.SaveChanges();
                }

                return RedirectToAction("ListCand");
            }
            return RedirectToAction("index");

        }

        public ActionResult ListCand()
        {
            test_techniqueEntities db = new test_techniqueEntities();
            var list =db.candidatures.ToList();
            return View(list);
            
        }

        public ActionResult index()
        {
            return View("AddCand");
        }

        //[HttpGet]
        //public ActionResult Searchid(string txtNom)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        test_techniqueEntities db = new test_techniqueEntities();
        //        var a = db.candidatures.Where(o => o.nom == txtNom).ToList();
        //        return View(a);
        //    }

        //    return RedirectToAction("ListCand");
        //}


        //public ActionResult Search()
        //{

        //    return View("Searchid");
        //}
    }
}