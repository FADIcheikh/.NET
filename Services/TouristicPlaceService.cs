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
    public class TouristicPlaceService : Service<TouristicPlaces>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public TouristicPlaceService()
          : base(ut)
        { }

        //public TouristicPlaces getTouristicPlaceByLangAndAtt(string x, string y)
        //{
        //    return ut.getRepository<TouristicPlaces>().GetAll().Where(p => p.Latitude == x && p.Longitude == y).First();


        //}
        //public IEnumerable<TouristicPlaces> chercher(string date, string u)
        //{
        //    return ut.getRepository<TouristicPlaces>().GetAll().Where();


        //}
    }
}
