using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [Required]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName {
          get 

            {return LastName + ", " + FirstMidName;
            }
        }



        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
