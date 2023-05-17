using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {

        public int FlightId { get; set; }
        public string Airline { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        //le mm type de clé primaire de plane
        [ForeignKey("PlaneFK")]
        public int PlaneFK { get; set; }

        public  IList<Passenger> Passengers { get; set; }
        public  Plane Plane { get; set; }

      
    }
}
