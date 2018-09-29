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
    public class ReservationOfferServices: Service<ReservationOffer>, IReservationOfferServices
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public ReservationOfferServices() : base(ut)
        {

        }
    }
}
