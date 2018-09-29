using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entites
{
  public   class ReservationOffer
    {
        [Key]
        public int IdReservationOffer { get; set; }
        public int IdSimpleUser { get; set; }
        public int IdOffer { get; set; }
        public double unitPrice { get; set; }
        public int ticketsNumber { get; set; }
        public int ReservationStatus { get; set; } // 1 for confirmed 0 for canceled

        //navigation props
        public virtual User simpleUserReservationOffer { get; set; }
        //public virtual Offer offerReservation { get; set; }
    }
}
