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
    public class ReservationOfferController : Controller
    {
        // GET: ReservationOffer
        IReservationOfferServices resEvSer = null;
        public ReservationOfferController()
        {
            resEvSer = new ReservationOfferServices();
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

        //public ActionResult ReservationPerUser()
        //{
        //    var x = resEvSer.getReservationsOfferByUser(1);


        //    return View(x);
        //}

        //public ActionResult xx()
        //{
        //    var x = resEvSer.getOffersInterstUser(1);
        //    ViewBag.z = x;

        //    return View(x);
        //}

        // GET: ReservationOffer/Details/5
        public ActionResult Details(int id)
        {
            ReservationOffer RE = resEvSer.GetById(id);
            return View(RE);
        }

        // GET: ReservationOffer/Create
        public ActionResult Create()
        {
            ReservationOfferModel RE = new ReservationOfferModel();
            return View(RE);
        }

        // POST: ReservationOffer/Create
        [HttpPost]
        public ActionResult Create(ReservationOfferModel REM)
        {


            ReservationOffer RE = new ReservationOffer
            {
                IdOffer = 1,
                IdSimpleUser = 1,
                ticketsNumber = REM.ticketsNumber,
                unitPrice = REM.unitPrice,
                ReservationStatus = REM.ReservationStatus
            };



            resEvSer.Add(RE);
            resEvSer.Commit();
            resEvSer.Dispose();

            RedirectToAction("Create");
            return View();
        }




        //GET: ReservationOffer/Edit/5
        public ActionResult Edit(int id)
        {
            ReservationOffer RE = resEvSer.GetById(id);
            ReservationOfferModel REM = new ReservationOfferModel
            {
                ReservationStatus = RE.ReservationStatus,
                ticketsNumber = RE.ticketsNumber,
                unitPrice = RE.unitPrice
            };

            return View(REM);

        }
        // POST: ReservationOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReservationOfferModel REM)
        {
            ReservationOffer RE = resEvSer.GetById(id);

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

        // GET: ReservationOffer/Delete/5
        public ActionResult Delete(int id)
        {
            ReservationOffer RE = resEvSer.GetById(id);
            if (RE == null)
            {
                return HttpNotFound();
            }
            ReservationOfferModel REM = new ReservationOfferModel
            {
                ReservationStatus = RE.ReservationStatus,
                ticketsNumber = RE.ticketsNumber,
                unitPrice = RE.unitPrice,


            };

            return View(REM);
        }

        // POST: ReservationOffer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReservationOfferModel REM)
        {
            ReservationOffer RE = resEvSer.GetById(id);


            resEvSer.Delete(RE);
            resEvSer.Commit();
            return RedirectToAction("ReservationPerUser");



        }
    }
}