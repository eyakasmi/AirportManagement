using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{


    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane

    {
        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime ManufactureDate { get; set; }
        public int Capacity { get; set; }

        public virtual List<Flight> Flights { get; set; }

        public Plane(PlaneType planeType, DateTime manufactureDate, int capacity)
        {
            PlaneType = planeType;
            ManufactureDate = manufactureDate;
            Capacity = capacity;
        }

        public Plane()
        {
        }

        public override string ToString()
        {
            return "PlaneType: " + PlaneType + " ManufactureDate: " + ManufactureDate + " Capacity: " + Capacity;
        }
    }
}
