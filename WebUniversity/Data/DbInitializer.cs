using WebUniversity.Models;
using System;
using System.Linq;
namespace WebUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Students.Any())
            {
                return; // DB has been seeded
            }
            var students = new Student[]
            {
new Student{FirstMidName="Daniel",LastName="Bigelow",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Daniel",LastName="Bowan",EnrollmentDate=DateTime.Parse("2012-09-01")},
new Student{FirstMidName="Kole",LastName="Frazier",EnrollmentDate=DateTime.Parse("2013-09-01")},
new Student{FirstMidName="Jed",LastName="Krouse",EnrollmentDate=DateTime.Parse("2012-09-01")},
new Student{FirstMidName="Jonathan",LastName="Wheeler",EnrollmentDate=DateTime.Parse("2012-09-01")},
new Student{FirstMidName="Jared",LastName="Williams",EnrollmentDate=DateTime.Parse("2011-09-01")},
new Student{FirstMidName="Brigham",LastName="Young",EnrollmentDate=DateTime.Parse("2013-09-01")},
new Student{FirstMidName="Joseph",LastName="Smith",EnrollmentDate=DateTime.Parse("2015-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
            var courses = new Course[]
            {
new Course{CourseID=1050,Title="CS 3550 Advanced Database",Credits=4},
new Course{CourseID=4022,Title="CS 3100 Operating Systems",Credits=4},
new Course{CourseID=4041,Title="CS 2400 Project Managment",Credits=3},new Course{CourseID=1045,Title="Math 1210 Calculus I",Credits=4},
new Course{CourseID=3141,Title="Math 1060 Trigonometry",Credits=3},
new Course{CourseID=2021,Title="Engl 1010 Composition",Credits=3},
new Course{CourseID=2042,Title="Engl 2010 Literature",Credits=3}
};
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
            {
new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.E},
new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.E},
new Enrollment{StudentID=3,CourseID=1050},
new Enrollment{StudentID=4,CourseID=1050},
new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.E},
new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
new Enrollment{StudentID=6,CourseID=1045},
new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
} 