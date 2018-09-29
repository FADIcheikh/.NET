using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
    public class ImageExperience
    {
        [Key]
        public int IdImageExperience { get; set; }
        public string nom { get; set; }

        public int experience_TPFK { get; set; }

        public string experience_UserFK { get; set; }

        [DataType(DataType.Date)]
        public DateTime experience_Date { get; set; }

        //navigationProps
        public virtual Experience experience { get; set; }
    }
}
