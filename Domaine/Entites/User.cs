using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Domaine.Entites
{
    public class User : IdentityUser
    {

        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }        
        public string image { get; set; }
        //navigation Props
        public virtual ICollection<ReservationEvent> listReservationsEventperUser { get; set; }

        public virtual ICollection<ReservationOffer> listReservationOfferperUser { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
