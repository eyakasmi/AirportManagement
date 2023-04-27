﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {


        public string PassportNumber { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public int? TelNumber { get; set; }
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate;
        }
       
        public bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return CheckProfile(firstName,lastName) && EmailAddress ==  email;
        }

        public bool login (string firstName, string lastName, string email=null)
        {
            return email!=null ? CheckProfile(firstName, lastName, email) : CheckProfile(firstName, lastName);
        }
        
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
