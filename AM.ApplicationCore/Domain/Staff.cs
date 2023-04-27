using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {

        [DataType(DataType.Currency)]

        public string Function { get; set; }
        public DateTime EmployementDate { get; set; }
        public double Salary { get; set; }

        public virtual void PassengerType()
        { 
            base.PassengerType();
            Console.WriteLine("I am a passenger i am a staff Member");
        }






    }
}
