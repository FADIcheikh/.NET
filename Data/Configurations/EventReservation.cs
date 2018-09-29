using Domaine.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class EventReservation: EntityTypeConfiguration<ReservationEvent>
    {
        public EventReservation()
        {
            HasRequired(x => x.simpleUserReservationEvent).WithMany(x => x.listReservationsEventperUser).HasForeignKey(x => x.IdSimpleUser).WillCascadeOnDelete();
            HasRequired(x => x.eventReservation).WithMany(x => x.listReservationEventPerEvent).HasForeignKey(x => x.IdEvent).WillCascadeOnDelete();
        }
    }
}
