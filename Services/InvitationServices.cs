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
    public class InvitationServices : Service<Invitation>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public InvitationServices()
           : base(ut)
        { }

        public IEnumerable<User> getUsers()
        {
            return ut.getRepository<User>().GetAll();
        }

    }
}