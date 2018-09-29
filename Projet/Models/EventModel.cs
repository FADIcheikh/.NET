using Domaine.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projet.Models
{
    public class EventModel
    {

        [Key]
        public int IdEvent { get; set; }
        public string nameEvent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime startDateEvent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime endDateEvent { get; set; }
        public double priceEvent { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Touristic Place")]

        public int? TouristicPlaceId { get; set; } // ? nullable
        public virtual TouristicPlaces touristicPlace { get; set; }
        public IEnumerable<SelectListItem> TouristicPlaces { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public string Gender { get; set; }

        public IEnumerable<SelectListItem> Genders { get; set; }
        //navigationProps
        //public virtual ICollection<Offer> listOffers { get; set; }
        // public virtual ICollection<SimpleUser> listUsersPerEvent { get; set; }

        [EnumDataType(typeof(type))]
        public type Category { get; set; }
    }
}