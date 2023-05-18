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
    public class ReservationTicketConfiguration : IEntityTypeConfiguration<ReservationTicket>
    {

        //config de clé composé
        public void Configure(EntityTypeBuilder<ReservationTicket> builder)
        {
            builder.HasKey(rt => new
            {
                rt.PassengerFk,
                rt.TicketFk,
                rt.DateReservation
            });

            //remplace [foreignkey("TicketFk")]
            /*builder.HasOne(t => t.Passenger)
                .WithMany(t => t.ReservationTickets)
                .HasForeignKey(t => t.TicketFk);
            */
        }
    }
}
