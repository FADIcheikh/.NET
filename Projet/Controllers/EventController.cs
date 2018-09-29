using Domaine.Entites;
using Projet.Helper;
using Projet.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet.Controllers
{
    public class EventController : Controller
    {
        //Event e = null;
        ServicesEvent c = null;
        public EventController()
        {
            //e = new Event();
            c = new ServicesEvent();
        }

        // GET: Event
        public ActionResult Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var events1 = c.getProductByCategorie(search);

                List<EventModel> EM1 = new List<EventModel>();
                foreach (var item2 in events1)
                {
                    EM1.Add(
                        new EventModel
                        {
                            IdEvent = item2.IdEvent,
                            nameEvent = item2.nameEvent,
                            startDateEvent = item2.startDateEvent,
                            endDateEvent = item2.endDateEvent,
                            ImageUrl = item2.ImageUrl,
                            Gender = item2.gender,
                            TouristicPlaceId = item2.TouristicPlacesId,
                            priceEvent = item2.priceEvent
                        });
                }
                return View(EM1);
            }
            else
            {
                var events2 = c.GetAllEvent();
                List<EventModel> EM2 = new List<EventModel>();
                foreach (var item2 in events2)
                {
                    EM2.Add(
                        new EventModel
                        {
                            IdEvent = item2.IdEvent,
                            nameEvent = item2.nameEvent,
                            startDateEvent = item2.startDateEvent,
                            endDateEvent = item2.endDateEvent,
                            ImageUrl = item2.ImageUrl,
                            Gender = item2.gender,
                            TouristicPlaceId = item2.TouristicPlacesId,
                            priceEvent = item2.priceEvent
                        });
                }
                return View(EM2);
            }
        }


        // GET: Event/Details/5
        public ActionResult Details(int id)
        {

            Event e = c.GetById(id);

            EventModel em = new EventModel
            {
                IdEvent = e.IdEvent,
                nameEvent = e.nameEvent,
                description = e.description,
                startDateEvent = e.startDateEvent,
                endDateEvent = e.endDateEvent,
                Gender = e.gender,
            ImageUrl = e.ImageUrl,
                touristicPlace = c.getPlaceById(e.TouristicPlacesId)
            };
            return View(em);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            //var evnt = new EventModel();
            //List<String> pay = new List<String> { "maroc", "algérie" };
            //evnt.Payss = pay.ToSelectListItem();
            //return View(pay);

            var eventM = new EventModel();
            eventM.TouristicPlaces = c.GetAllTouristicPlaces().ToSelectListItems();
            List<string> genres = new List<string> { "Music", "Dance", "Sport", "Film", "Foot","Théatre" };
            eventM.Genders = genres.ToSelectListItem();
            return View(eventM);
        }




        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventModel E, HttpPostedFileBase Image, string x)
        {
            if (!ModelState.IsValid || Image == null || Image.ContentLength == 0)
            {
                RedirectToAction("Create");
            }

            E.ImageUrl = Image.FileName;
            Event Event1 = new Event
            {
                nameEvent = E.nameEvent,
                gender = E.Gender,
                priceEvent = E.priceEvent,
                startDateEvent = E.startDateEvent,
                endDateEvent = E.endDateEvent,
                description = E.description,
                ImageUrl = E.ImageUrl,
                TouristicPlacesId = E.TouristicPlaceId.Value,
                userId = x

            };
            c.Add(Event1);
            c.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/img"), Image.FileName);
            Image.SaveAs(path);

            return RedirectToAction("Index");
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event e = c.GetById(id);
            EventModel em = new EventModel
            {
                IdEvent = e.IdEvent,
                nameEvent = e.nameEvent,
                startDateEvent = e.startDateEvent,
                endDateEvent = e.endDateEvent,
                ImageUrl = e.ImageUrl,
                priceEvent = e.priceEvent,
                description = e.description,
                TouristicPlaceId = e.TouristicPlacesId

            }
            ;

            var eventM = new EventModel();
            em.TouristicPlaces = c.GetAllTouristicPlaces().ToSelectListItems();
            return View(em);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(EventModel E, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid )
            {
                RedirectToAction("Edit");
            }
            Event Event = c.GetById(E.IdEvent);
            if( Image != null ) { 
            Event.ImageUrl = Image.FileName;
            }
            Event.nameEvent = E.nameEvent;
            Event.priceEvent = E.priceEvent;
            Event.startDateEvent = E.startDateEvent;
            Event.gender = E.Gender;
            Event.endDateEvent = E.endDateEvent;
            Event.TouristicPlacesId = E.TouristicPlaceId.Value;
            Event.description = E.description;
            c.Update(Event);
            c.Commit();
            if (Image != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/img"), Image.FileName);
                Image.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            return View();

        }

        public ActionResult Form(int id, FormCollection collection)
        {

            return View();

        }

        // GET: Event
        public ActionResult UserEvent(string id)
        {
            var events = c.GetUserEvent(id);
            List<EventModel> EM = new List<EventModel>();
            foreach (var item in events)
            {
                EM.Add(
                    new EventModel
                    {
                        IdEvent = item.IdEvent,
                        nameEvent = item.nameEvent,
                        startDateEvent = item.startDateEvent,
                        endDateEvent = item.endDateEvent,
                        ImageUrl = item.ImageUrl,
                        TouristicPlaceId = item.TouristicPlacesId,
                        priceEvent = item.priceEvent
                    });
            }
            return View(EM);
        }
    }
}
