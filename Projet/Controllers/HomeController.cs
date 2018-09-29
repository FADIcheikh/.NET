using Domaine.Entites;
using Projet.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexUser()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //recuperation des données
        public ActionResult ProfilDetails(string id)
        {
            ServiceProfil cs = new ServiceProfil();
            User C = cs.GetById(id);

            ProfilModels p = new ProfilModels()
            {

                Prenom = C.Prenom,
                Nom = C.Nom,
                Sexe = C.Sexe,
                DateNaissance = C.DateNaissance,
                Email = C.Email,
                Pays = C.Pays,
                Ville = C.Ville,
                Rue = C.Rue,
                image = C.image


            };

            return View(p);
        }

    }
}