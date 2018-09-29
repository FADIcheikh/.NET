using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class ProfilModels
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public string image { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }
        


    }
}
