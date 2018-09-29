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
 public   class ReservationEventServices : Service<ReservationEvent>, IReservationEventServices
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public ReservationEventServices() : base(ut)
        {

        }
        public IEnumerable<ReservationEvent> getReservationsEventByEvent(int idEvent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservationEvent> getReservationsEventByUser(string idSimpleUSer)
        {
            return ut.getRepository<ReservationEvent>().GetMany(x => x.IdSimpleUser == idSimpleUSer);
        }


        // nombre de réservations par User 
        public int getReservationsEventByUserzzz(string idSimpleUSer)
        {
            return ut.getRepository<ReservationEvent>().GetMany(x => x.IdSimpleUser == idSimpleUSer).Count();
        }



        //*******************************************************************************************
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

        // traitement comapraison categories
        public type getEventsInterstUser(string idSimpleUser)
        {
            IEnumerable<Event> EventFoot = null;
            IEnumerable<Event> EventMusic = null;
            IEnumerable<Event> EventTheatre = null;

            int nbrFootEvent = 0;
            int nbrMusciEvent = 0;
            int nbrTheatreEvent = 0;
            var ListResPerUser = ut.getRepository<ReservationEvent>().GetMany(x => x.IdSimpleUser == idSimpleUser);

            foreach (var item in ListResPerUser)
            {
                EventFoot = getEventsByCategoryFoot(item.IdEvent);
                EventMusic = getEventsByCategoryMusic(item.IdEvent);
                EventTheatre = getEventsByCategoryTheatre(item.IdEvent);
            }

            nbrFootEvent = EventFoot.Count();
            nbrMusciEvent = EventMusic.Count();
            nbrTheatreEvent = EventTheatre.Count();

            //X>y>z
            if (nbrFootEvent > nbrMusciEvent && nbrFootEvent > nbrTheatreEvent)
            {
                //return "nbrFootEvent";

                return type.Foot;

            }
            else
            {
                if (nbrMusciEvent > nbrTheatreEvent)
                {
                    // return "nbrMusciEvent";

                    return type.Music;

                }
                else
                {
                    // return "nbrTheatreEvent";

                    return type.Theatre;
                }
            }


        }

        //suggestion Event 

        public Event SuggestionEvent(string idSimpleUser)
        {

            return ut.getRepository<Event>().GetMany(x => x.IdEvent != null).Where(x => x.Category.Equals(getEventsInterstUser(idSimpleUser))).First(); ;
        }
    }
}
