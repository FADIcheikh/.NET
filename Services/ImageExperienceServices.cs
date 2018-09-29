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
    public class ImageExperienceServices : Service<ImageExperience>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ImageExperienceServices()
          : base(ut)
        { }

        public List<ImageExperience> FindByIdExp(string d, int x, string u)
        {
            return ut.getRepository<ImageExperience>().GetAll().Where(i => i.experience_Date.ToString() == d && i.experience_TPFK == x && i.experience_UserFK == u).ToList();
        }

    }
}
