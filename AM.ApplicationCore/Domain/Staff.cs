﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {

        

        public string Function { get; set; }
        public DateTime EmployementDate { get; set; }

        [DataType(DataType.Currency)] //une valeur monétaire
        public double Salary { get; set; }

        public virtual void PassengerType()
        { 
            base.PassengerType();
            Console.WriteLine("I am a passenger i am a staff Member");
        }






    }
}
