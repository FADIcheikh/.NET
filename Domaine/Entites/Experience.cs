using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
    public class Experience
    {
        public string Nom { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, 20)]
        public int note { get; set; }
        public string type { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public ICollection<ImageExperience> ListImage { get; set; }

        //[ForeignKey("IdSimpleUserCreator")]
        public string UserFK { get; set; }

        [ForeignKey("IdTouristicPlace")]
        public int TPFK { get; set; }
        //navigationProps
        //public virtual SimpleUser IdSimpleUserCreator { get; set; }
        public virtual TouristicPlaces IdTouristicPlace { get; set; }
    }
}
