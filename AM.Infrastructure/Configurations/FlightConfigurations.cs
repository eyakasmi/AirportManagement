using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfigurations : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //changement du nom de la table associative ;
            builder.HasMany(f => f.Passengers) // f = flight
                .WithMany(p => p.Flights)//p= passenger
                .UsingEntity(p => p.ToTable("Vols"));

            // config de 1-* en changeant le nom de FK
            // <=> [ForeignKey("PlaneFK")]
            builder.HasOne(f => f.Plane)
                .WithMany(p => p.Flights)
                .HasForeignKey(p => p.PlaneFK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
