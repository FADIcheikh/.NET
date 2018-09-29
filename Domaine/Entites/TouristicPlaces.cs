using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
    public class TouristicPlaces
    {
        [Key]
        public int IdTouristicPlaces { get; set; }
        public string country { get; set; }
        public string delegation { get; set; }
        public string nameTouristicPlace { get; set; }
        public string TouristicPlaceImage { get; set; }

        // virtual public ICollection<Event> Events { get; set; }


    }
}
