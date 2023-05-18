// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");

//constructeur par défaut
Plane plane = new Plane();
plane.Capacity = 300;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;
//Constructeur paramétré
Plane plane2 = new Plane(PlaneType.Boing,new DateTime(2023,04,12),200);

//initialiseur d'objet 
Plane plane3 = new Plane
{
    Capacity = 100,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boing,
    PlaneId = 2
};

Passenger passenger1 = new Passenger { FullName = new(){
    FirstName = "steave", 
    LastName = "jobs"
}, EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };
Console.WriteLine(passenger1.CheckProfile("Steave", "Jobs"));
Console.WriteLine(passenger1.CheckProfile("steave", "jobs", "steeve.jobs@gmail"));


ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;
foreach (var flight in serviceFlight.GetFlightDates("Paris"))
{
    Console.WriteLine(flight);
}
Console.WriteLine("*******ShowFlightDetails*******");
serviceFlight.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("*******ProgrammedFlightNumber*******");
Console.WriteLine(serviceFlight.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));

Console.WriteLine("*******DurationAverage*******");
Console.WriteLine(serviceFlight.DurationAverage("Lisbonne"));

/*foreach(var flight in sf.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(flight);
}*/