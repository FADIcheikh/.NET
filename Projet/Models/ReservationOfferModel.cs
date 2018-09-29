using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet.Models
{
    public class ReservationOfferModel
    {
        public double unitPrice { get; set; }
        public int ticketsNumber { get; set; }
        public int ReservationStatus { get; set; } // 1 for confirmed 0 for canceled
    }
}