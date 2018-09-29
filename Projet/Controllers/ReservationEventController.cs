using Data;
using Domaine.Entites;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projet.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;

namespace Projet.Controllers
{
    public class ReservationEventController : Controller
    {

        // GET: ReservationEvent
        IReservationEventServices resEvSer = null;
        ServicesEvent cccc = null;
  
        public ReservationEventController()
        {
            resEvSer = new ReservationEventServices();
            cccc = new ServicesEvent();
        }
        




     

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        resEvSer.Dispose();
        //    }
        //    base.Dispose(disposing);

        //}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReservationPerUser()
        {
            var x = resEvSer.getReservationsEventByUser(User.Identity.GetUserId());

            return View(x);
        }

        //Nbre Reservation
        public ActionResult nbre()
        {
            var x = resEvSer.getEventsInterstUser(User.Identity.GetUserId());
            ViewBag.z = x;
            return View();
        }
        //Suggestion Event

        public ActionResult suggest()
        {
            var x = cccc.SuggestionEvent(User.Identity.GetUserId());

            EventModel EV = new EventModel
            {
                Category = x.Category,
                nameEvent = x.nameEvent,
                priceEvent = x.priceEvent,
               description = x.description,
                ImageUrl = x.ImageUrl

            };
            ViewBag.z = x;
            return View(EV);
        }
        public ActionResult xx()
        {
            var x = resEvSer.getEventsInterstUser(User.Identity.GetUserId());
            ViewBag.z = x;

            return View(x);
        }

        // GET: ReservationEvent/Details/5
        public ActionResult Details(int id)
        {
            ReservationEvent RE = resEvSer.GetById(id);
            return View(RE);
        }

        // GET: ReservationEvent/Create
        public ActionResult Create(int id)
        {
            Event e = cccc.GetById(id);
            ReservationEventModel RE = new ReservationEventModel();
            return View(RE);
        }

        // POST: ReservationEvent/Create
        [HttpPost]
        public ActionResult Create(ReservationEventModel REM,int id)
        {


            ReservationEvent RE = new ReservationEvent
            {    IdEvent =id,
                IdSimpleUser = User.Identity.GetUserId(),
                ticketsNumber = REM.ticketsNumber,
                unitPrice = REM.unitPrice,
                ReservationStatus = REM.ReservationStatus
            };



            resEvSer.Add(RE);
            resEvSer.Commit();
            resEvSer.Dispose();

            return RedirectToAction("ReservationPerUser");
          
        }




        //GET: ReservationEvent/Edit/5
        public ActionResult Edit(int id)
        {
            ReservationEvent RE = resEvSer.GetById(id);
            ReservationEventModel REM = new ReservationEventModel
            {
                ReservationStatus = RE.ReservationStatus,
                ticketsNumber = RE.ticketsNumber,
                unitPrice = RE.unitPrice
            };

            return View(REM);

        }
        // POST: ReservationEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReservationEventModel REM)
        {
            ReservationEvent RE = resEvSer.GetById(id);

            try
            {
                resEvSer.Update(RE);
                UpdateModel(RE);

                resEvSer.Commit();
                return RedirectToAction("ReservationPerUser");


            }
            catch
            {


                return View(RE);
            }


        }

        // GET: ReservationEvent/Delete/5
        public ActionResult Delete(int id)
        {
            ReservationEvent RE = resEvSer.GetById(id);
            if (RE == null)
            {
                return HttpNotFound();
            }
            ReservationEventModel REM = new ReservationEventModel
            {
                ReservationStatus = RE.ReservationStatus,
                ticketsNumber = RE.ticketsNumber,
                unitPrice = RE.unitPrice,


            };

            return View(REM);
        }


        // POST: ReservationEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReservationEventModel REM)
        {
            ReservationEvent RE = resEvSer.GetById(id);


            resEvSer.Delete(RE);
            resEvSer.Commit();
            return RedirectToAction("ReservationPerUser");



        }
    }
}