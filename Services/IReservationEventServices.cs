using Domaine.Entites;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public  interface IReservationEventServices : IService<ReservationEvent>
    {
        IEnumerable<ReservationEvent> getReservationsEventByUser(string idSimpleUSer);
        IEnumerable<ReservationEvent> getReservationsEventByEvent(int idEvent);
        type getEventsInterstUser(string idSimpleUser);
        Event SuggestionEvent(string idSimpleUser);
    }
}
