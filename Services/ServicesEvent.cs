using Data;
using Data.Infrastructure;
using Domaine.Entites;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesEvent : Service<Event>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ServicesEvent()
           : base(ut)
        {
        }
        public IEnumerable<Event> GetAllEvent()
        {
            return ut.getRepository<Event>().GetAll();
        }
        public IEnumerable<TouristicPlaces> GetAllTouristicPlaces()
        {
            return ut.getRepository<TouristicPlaces>().GetAll();
        }


        public IEnumerable<Event> getProductByCategorie(string gender)
        {

            return ut.getRepository<Event>().GetAll().Where(x => x.gender.Equals(gender));
        }
        public IEnumerable<Event> Rechercher(string name)
        {
            var listText = new List<String>();
            ApplicationDbContext db = new ApplicationDbContext();

            var apps = from m in db.Events
                       select m;

            if (!String.IsNullOrEmpty(name))
            {
                apps = apps.Where(s => s.nameEvent.Contains(name));
            }
            return apps;
        }
        public IEnumerable<Event> RechercheFreeEvent()
        {
            return ut.getRepository<Event>().GetMany(m => m.priceEvent.Equals(0)).ToList();
        }
        public List<Event> GetUserEvent(string id)
        {
            return ut.getRepository<Event>().GetMany(m => m.userId.Equals(id)).ToList();
        }
        public List<Event> Events(string gendere)
        {
            var u = from Event e in ut.getRepository<Event>().GetMany()
                    where e.gender.Equals(gendere)
                    select e;
            //group e by e.gender into s
            //select s;

            return u.ToList();
        }
        public TouristicPlaces getPlaceById(int id)
        {
            return ut.getRepository<TouristicPlaces>().GetById(id);
        }
        public IEnumerable<Event> GetEventsByGender(string gender)
        {
            return ut.getRepository<Event>().GetMany(m => m.gender.Equals(gender))
                .ToList();
        }
        //public IEnumerable<Event> RechercheFreeEventByUser(User u)
        //{
        //    return ut.getRepository<Event>().GetMany(m => m.priceEvent.Equals(0)).Where(m => m.UserId.Equals(u.IdUser)).ToList();
        //}
        //***********************************************************************************
        //***********************************************************************************

        //recuperer les evenements de la categorie foot
        public IEnumerable<Event> getEventsByCategoryFoot(int IdEvent)
        {
            return ut.getRepository<Event>().GetMany(x => x.IdEvent == IdEvent).Where(x => x.Category == type.Foot);
        }

        //recuperer les evenements de la categorie Music
        public IEnumerable<Event> getEventsByCategoryMusic(int IdEvent)
        {
            return ut.getRepository<Event>().GetMany(x => x.IdEvent == IdEvent).Where(x => x.Category == type.Music);
        }

        //recuperer les evenements de la categorie Theatre
        public IEnumerable<Event> getEventsByCategoryTheatre(int IdEvent)
        {
            return ut.getRepository<Event>().GetMany(x => x.IdEvent == IdEvent).Where(x => x.Category == type.Theatre);
        }

        public Event SuggestionEvent(string idSimpleUser)
        {

            return ut.getRepository<Event>().GetMany(x => x.IdEvent != null).Where(x => x.Category.Equals(new ReservationEventServices().getEventsInterstUser(idSimpleUser))).First(); ;
        }
    }
}
