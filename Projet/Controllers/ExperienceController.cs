using Data;
using Domaine.Entites;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projet.Helper;
using Projet.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projet.Controllers
{
    public class ExperienceController : Controller
    {

        ExperienceServices cs = null;
        ImageExperienceServices ics = null;
        TouristicPlaceService ts = null;
        ApplicationDbContext ctx;
        
        public ExperienceController()
        {
            cs = new ExperienceServices();
            ics = new ImageExperienceServices();
            ts = new TouristicPlaceService();
            ctx = new ApplicationDbContext();
        }


        public User getCurrentUser()
        {

            var UserManager = new UserManager<User>(new UserStore<User>(ctx));
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            return currentUser;
        }


        // GET: Experiences
        public ActionResult Index()
        {
            var exp = cs.GetAll();
            List<ExperienceModels> lum = new List<ExperienceModels>();
            foreach (var e in exp)
            {
                lum.Add(new ExperienceModels
                {
                    Nom = e.Nom,
                    Description = e.Description,
                    TPFK = e.TPFK,
                    UserFK = e.UserFK,
                    Date = e.Date,


                    ListImage = ics.FindByIdExp(e.Date.ToString(), e.TPFK, e.UserFK)



                });

            }

            return View(lum);
        }

        // GET: Experiences/ListByUser/5
        public ActionResult ListByUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exp = cs.GetListByUser(id);
            List<ExperienceModels> lum = new List<ExperienceModels>();

            foreach (var e in exp)
            {
                lum.Add(new ExperienceModels
                {
                    Nom = e.Nom,
                    Description = e.Description,
                    TPFK = e.TPFK,
                    UserFK = e.UserFK,
                    Date = e.Date,
                    ListImage = ics.FindByIdExp(e.Date.ToString(), e.TPFK, id)


                });

            }
            if (exp == null)
            {
                return HttpNotFound();
            }
            return View(lum);
        }

        // GET: Experiences/Details/5
        public ActionResult Details(int? id, string u, string d)
        {
            if (id == null || u == null || d == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience C = cs.GetExperience(id.Value, u, d.ToString());
            List<ImageExperience> l = ics.FindByIdExp(d, id.Value, u);


            ViewBag.x = l;
            ExperienceModels um = new ExperienceModels
            {
                TPFK = C.TPFK,
                UserFK = C.UserFK,
                Date = C.Date,
                Description = C.Description,
                Nom = C.Nom,

                type = C.type,
                note = C.note,
                ListImage = l


            };
            if (C == null)
            {
                return HttpNotFound();
            }
            return View(um);
        }

        // GET: Experiences/Create
        public ActionResult Create(string x)
        {

            List<string> L = new List<string> { "Business", "In Couple", "With Family", "Friends", "En Famille" };
            ViewBag.x = L.ToSelectItem();
            IEnumerable<TouristicPlaces> lt = ts.GetAll();
            ViewBag.y = lt.dropDownList();

            return View();
        }

        // POST: Experiences/Create
        [HttpPost]
        public ActionResult Create(ExperienceModels C, ICollection<HttpPostedFileBase> Image,string x)
        {

            if (!ModelState.IsValid || Image == null)
            {
                RedirectToAction("Create");
            }

            Experience p = new Experience
            {
                UserFK = x,
                TPFK = C.TPFK,
                Date = C.Date,
                Description = C.Description,
                Nom = C.Nom,
                type = C.type,
                note = C.note

            };
            cs.Add(p);
            cs.Commit();


            foreach (var item in Image)
            {
                ImageExperience i = new ImageExperience
                {
                    nom = item.FileName,
                    experience_Date = C.Date,
                    experience_UserFK = x,
                    experience_TPFK = C.TPFK

                };
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), item.FileName);
                item.SaveAs(path);
                ics.Add(i);
                ics.Commit();
            }



            return RedirectToAction("ListByUser/" + x);

        }

        // GET: Experiences/Edit/5
        public ActionResult Edit(int id, string u, string d)
        {
            List<ImageExperience> l = ics.FindByIdExp(d, id, u);
            Experience e = cs.GetExperience(id, u, d);
            ExperienceModels em = new ExperienceModels
            {
                Nom = e.Nom,
                Date = e.Date,
                Description = e.Description,
                ListImage = l,
                note = e.note,
                type = e.type
            };

            List<string> L = new List<string> { "Business", "In Couple", "With Family", "Friends", "En Famille" };
            ViewBag.x = L.ToSelectItem();
            IEnumerable<TouristicPlaces> lt = ts.GetAll();
            ViewBag.y = lt.dropDownList();
            return View(em);
        }

        // POST: Experiences/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string u, string d, ExperienceModels em)
        {
            try
            {
                Experience e = cs.GetExperience(id, u, d);
                e.Nom = em.Nom;
                e.Description = em.Description;
                //e.ListImage = em.ListImage;
                e.note = em.note;
                e.type = em.type;
                cs.Update(e);
                cs.Commit();

                return RedirectToAction("ListByUser/" + u);
            }
            catch
            {
                return View();
            }
        }

        // GET: Experiences/Delete/5
        public ActionResult Delete(int id, string u, string d)
        {
            Experience e = cs.GetExperience(id, u, d);
            cs.Delete(e);
            cs.Commit();

            return RedirectToAction("ListByUser/" + u);

        }

        // POST: Experiences/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ExperienceModels um)
        {
            try
            {
                //cs.Delete(cs.GetById(id));
                //cs.Commit();

                return RedirectToAction("");
            }
            catch
            {
                return View();
            }
        }

        // POST: Experiences/Delete/5
        [HttpPost]
        public ActionResult DeleteImage(int id, string u, string d)
        {
            try
            {
                cs.Delete(cs.GetById(id));
                cs.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult map()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MapRecherche(string x, string y)
        {
            //TouristicPlaces tp = ts.getTouristicPlaceByLangAndAtt(x, y);
            return View("Create");

        }
    }
}