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
    public class ExperienceServices : Service<Experience>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ExperienceServices()
          : base(ut)
        { }

        public IEnumerable<Experience> GetListByUser(string id)
        {
            return ut.getRepository<Experience>().GetAll().
                Where(l => l.UserFK == id);
        }

        public Experience GetExperience(int x, string u, string d)
        {
            return ut.getRepository<Experience>().GetAll().
                Where(i => i.Date.ToString() == d && i.TPFK == x && i.UserFK == u).First();
        }

        public IEnumerable<TouristicPlaces> TouristicPlaceVisitParUserOnAspecificDate(string d, string u)
        {
            var y = ut.getRepository<Experience>().GetAll().Where(x => x.UserFK == u && x.Date.ToString() == d);
            List<TouristicPlaces> l = null;
            foreach (var item in y)
            {
                l.Add(item.IdTouristicPlace);
            }
            return l;
        }

        public TouristicPlaces BestTouristicPlaceBasedOnnoteOExperience(string d)
        {
            var y = ut.getRepository<Experience>().GetAll().Where(x => x.Date.ToString() == d).OrderBy(x => x.note).First();
            return y.IdTouristicPlace;
        }
    }
}
