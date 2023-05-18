using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext :DbContext 
    {
        //1-entités  

        //DbSet <Entity> tableName {get ; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }



        //2- ajouter chaine de connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfigurations());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationTicketConfiguration());

            //2eme methode de configuration de type complexe
            modelBuilder.Entity<Passenger>()

                 .OwnsOne(p => p.FullName, f =>
                 {
                     f.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                     f.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
                 });

            //Heritage

            //configuration de TPH
           /* modelBuilder.Entity<Passenger>()
            .HasDiscriminator<int>("PassengerType")
            .HasValue<Passenger>(0)
            .HasValue<Traveller>(1)
            .HasValue<Staff>(2);*/

            //configuration de TPT
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");


        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
             configurationBuilder.Properties<DateTime>() // ay haja entre <> : est un type de prop / et entre () : un nom de prop
                .HaveColumnType("Date"); //type de la colone

            /*configurationBuilder.Properties<string>()
                .HaveMaxLength(50); // chaque strig a max lenghth = 50 */
        }

    



    }

}
