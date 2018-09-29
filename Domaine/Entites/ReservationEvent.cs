using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
    [Serializable]
    [DataContract]

    public class ReservationEvent
    {
        [Key]
        
        public int IdReservationEvent { get; set; }
        public string IdSimpleUser { get; set; }
        public int IdEvent { get; set; }
        [DataMember]
        public double unitPrice { get; set; }
        public int ticketsNumber { get; set; }
        public int ReservationStatus { get; set; } // 1 for confirmed 0 for canceled
        //navigation props
        public virtual User simpleUserReservationEvent { get; set; }
        public virtual Event eventReservation { get; set; }

    }
}
