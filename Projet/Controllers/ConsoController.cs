using Domaine.Entites;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projet.Controllers
{
    public class ConsoController : ApiController
    {
        ReservationEventServices resEvSer = null;
        

        public ConsoController()
        {
            resEvSer = new ReservationEventServices();
          
        }
       
        public IEnumerable<ReservationEvent> getAll()
        {
            return resEvSer.GetAll();
        }
    }
}
