using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }

        public string nameEvent { get; set; }
        public string description { get; set; }

        public string gender { get; set; }
        [Display(Name = "Start Date Event")]
        [DataType(DataType.DateTime)]

        public DateTime startDateEvent { get; set; }
        [Display(Name = "End Date Event")]
        [DataType(DataType.DateTime)]
        public DateTime endDateEvent { get; set; }
        public double priceEvent { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }


        public int TouristicPlacesId { get; set; } // ? nullable

        [ForeignKey("TouristicPlacesId")]
        public virtual TouristicPlaces TouristicPlaces { get; set; }

        [EnumDataType(typeof(type))]
        public type Category { get; set; }

        //navigationProps



        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual User User { get; set; }

        public virtual ICollection<ReservationEvent> listReservationEventPerEvent { get; set; }
    }

    public enum type
    {
        Foot, Music, Theatre
    }
}
