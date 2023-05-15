using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {

        public IList<Flight> Flights { get; set; } = new List<Flight>();

        //la liste des dates de vols d’une destination passée en paramètre.
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
            //II.6-Les structures itératives: With for
            //for (int j = 0; j < Flights.Count; j++)
            //    if (Flights[j].Destination.Equals(destination))
            //        ls.Add(Flights[j].FlightDate);

            //II.7-Les structures itératives: With foreach 
            //foreach(Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;

            //III-Le langage LINQ
            // var query = from f in Flights
            //          where
            //           f.Destination.Equals(destination)
            //             select f.FlightDate;
            //  return query.ToList();

            //Lambda expressions
            return Flights
                .Where(flight => flight.Destination == destination)
                .Select(flight => flight.FlightDate)
                .ToList();
        }

        //vols en fonction de type de filtre et sa valeur.
        //GetFlights(“Destination”, “Paris”)
        public void GetFlights(string filterType, string filterValue)
        {
            /* List<Flight> ls = new List<Flight>();
             if (filterType== "Destination")
             {
                 foreach (Flight f in Flights)
                     if (f.Destination.Equals(filterValue))
                         ls.Add(f);
                 return ls;

             }
             else if (filterType == "FlightDate")
             {
                 foreach (Flight f in Flights)
                     if (f.FlightDate.Equals(filterValue))
                         ls.Add(f);
                 return ls;
             }
             else if (filterType == "EffectiveArrival")
             {
                 foreach (Flight f in Flights)
                     if (f.EffectiveArrival.Equals(filterValue))
                         ls.Add(f);
                 return ls;
             }
             else if (filterType == "Plane")
             {
                 foreach (Flight f in Flights)
                     if (f.Plane.Equals(filterValue))
                         ls.Add(f);
                 return ls;
             }
             else if (filterType == "EstimatedDuration")
             {
                 foreach (Flight f in Flights)
                     if (f.EstimatedDuration.Equals(filterValue))
                         ls.Add(f);
                 return ls;
             }
             else 
             {
                 return ls ;
             }
             */
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))

                            Console.WriteLine(f);

                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Domain.Plane plane)
        {
         //   var req = from f in Flights
          //            where f.Plane == plane
          //            select new { f.FlightDate, f.Destination };
          //  foreach (var v in req)
          //      Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);

            var flightLambda = Flights
                .Where(f => f.Plane == plane)
                .Select(f => new { f.FlightDate, f.Destination });
            foreach (var l in flightLambda)
                Console.WriteLine( l.FlightDate + " " + l.Destination);

        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //  DateTime endtDate = startDate.AddDays(7);

            //  var req = from f in Flights
            //            where (startDate <= f.FlightDate) && (f.FlightDate <= endtDate)
            //            select f;
            //  return req.Count();

            //Lambda
            return Flights
                .Where(f => (f.FlightDate - startDate).TotalDays < 7 && DateTime.Compare(f.FlightDate, startDate) > 0)
                .Count();

        }

        public double DurationAverage(string destination)
        {
          //  var query = from f in Flights
          //               where f.Destination.Equals(destination) 
          //               select f.EstimatedDuration;
         //   return query.Average();

            return Flights
                .Where(f=> f.Destination.Equals(destination))
                .Select(f => f.EstimatedDuration)
                .Average();

        }

        public IList<Flight> OrderedDurationFlights()
        {
          //  var query = from f in Flights
          //              orderby f.EstimatedDuration descending
          //              select f;
          //  return query.ToList();

            return Flights
                .OrderByDescending(f => f.EstimatedDuration) 
                .ToList();
        }


        //public IEnumerable<Traveller> SeniorTravellers(Flight f)
        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from f in flight.Passengers.OfType<Traveller>() 
           //              orderby f.BirthDate
           //              descending select f;
           // return query.Take(3).ToList();

            //return query.Skip(3); => skip 3

           
            return Flights
                .OfType<Traveller>()
                .OrderByDescending(f => f.BirthDate)
                .Take(3)
                .ToList();


        }

        public void DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            foreach (var flight in req)
            {
                Console.WriteLine("Destination: " + flight.Key);
                foreach (var f in flight)
                    Console.WriteLine("Décollage: " + f.FlightDate);
            }


        }



    }
}
