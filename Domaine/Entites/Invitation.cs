using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
   public class Invitation
    {
        public string nomSender { get; set; }

        [ForeignKey("user")]
        public string UserFK { get; set; }
        public virtual User user { get; set; }
        public string InvitationState { get; set; }
        [ForeignKey("ev")]
        public int EventFK { get; set; }
        public virtual Event ev { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
