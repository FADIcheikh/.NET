using Domaine.Entites;
using Projet.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projet.Controllers
{
    public class InvitationController : Controller
    {

        InvitationServices cs = null;
        public InvitationController()
        {
            cs = new InvitationServices();
        }
        // GET: Invitation
        public ActionResult Index()
        {
            var invit = cs.getUsers();
       
            ViewBag.Message = 1;
           
            InvitationModels i = new InvitationModels
            {
                listeuser = invit


            };
            
            return View(i);
        }

        // GET: Invitation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invitation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invitation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invitation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invitation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invitation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invitation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult inviter(int e)
        {

            Invitation invitation = new Invitation
            {
                nomSender = "rim",

                Date = DateTime.Now,
                UserFK = "76e65166-ce17-4fa5-a769-f208cfd13578",
                EventFK = e,
                InvitationState = "refusé"

            };
            cs.Add(invitation);
            cs.Commit();
            return View();
        }
    }
}
