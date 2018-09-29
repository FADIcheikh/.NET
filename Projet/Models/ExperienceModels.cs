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
    public class ExperienceModels
    {
        public string Nom { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, 20)]
        public int note { get; set; }
        public string type { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd 00:00:00}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }
        public ICollection<ImageExperience> ListImage { get; set; }

        //[ForeignKey("IdSimpleUserCreator")]
        public string UserFK { get; set; }

        [ForeignKey("IdTouristicPlace")]
        public int TPFK { get; set; }
        //navigationProps
        //public virtual SimpleUser IdSimpleUserCreator { get; set; }
        public virtual TouristicPlaces IdTouristicPlace { get; set; }

        //public IEnumerable<SelectListItem> Types { get; set; }
    }
}
