using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _00010358.Models
{
    public class Student
    {
        [DisplayName("ID")]
        public int StudentID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Enter your first name here!")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter your last name here!")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Enter your gmail address here!")]
        [RegularExpression(@"\w+([-+.]\w+)*@(gmail\.com)", ErrorMessage = "Enter your gmail address here!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter your age here!")]
        public int Age { get; set; }

        [Phone]
        [Required(ErrorMessage = "Enter your phone here!")]
        [RegularExpression(@"^[+]{1}[9]{1}[9]{1}[8]{1}[9]{1}[0-9]{8}$", ErrorMessage = "Enter your phone number starting with +9989...!")]
        public string Phone { get; set; }

        [DisplayName("Course ID")]
        [Required(ErrorMessage = "Please select one of the options")]
        public int CourseId { get; set; }
    }
}
