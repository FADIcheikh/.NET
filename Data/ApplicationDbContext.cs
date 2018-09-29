using Domaine.Entites;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("Name=PI", throwIfV1Schema: false)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<TouristicPlaces> TouristicPlaces { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<ImageExperience> ImageExperience{ get; set; }

        public DbSet<ReservationEvent> ReservationEvents { get; set; }
        public DbSet<ReservationOffer> ReservationOffers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Conventions.Add(new Datetime2Convention());

            modelBuilder.Entity<Invitation>()
               .HasKey(r => new { r.EventFK, r.UserFK });

            modelBuilder.Entity<Experience>()
                .HasKey(r => new { r.TPFK, r.UserFK, r.Date });
            modelBuilder.Entity<ImageExperience>()
                           .HasRequired(a => a.experience)
               .WithMany(c => c.ListImage)
               .HasForeignKey(a => new { a.experience_TPFK, a.experience_UserFK, a.experience_Date })
               .WillCascadeOnDelete(true);
        }
    }
}
