using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {


        // public int Id { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [MinLength(3, ErrorMessage ="Invalid!"),MaxLength(25)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name ="Date Of Birth")]
        //[DisplayName="Date Of Birth"]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int? TelNumber { get; set; }

        [DataType(DataType.EmailAddress)]
       // [EmailAddress]
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
