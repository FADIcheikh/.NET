using Domaine.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class UserModels
    {

        [Key]
        public string IdUser { get; set; }
        public string nomUser { get; set; }
        public virtual ICollection<Invitation> invitations { get; set; }

    }
}
