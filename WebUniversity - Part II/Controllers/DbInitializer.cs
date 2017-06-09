using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebUniversity.Models;


namespace WebUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Daniel",   LastName = "Bigelow",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Daniel", LastName = "Bowen",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Kole",   LastName = "Frazier",
                    EnrollmentDate = DateTime.Parse("2016-09-01") },
                new Student { FirstMidName = "Jed",    LastName = "Krause",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Jonathan",      LastName = "Wheeler",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Jared",    LastName = "Williams",
                    EnrollmentDate = DateTime.Parse("2014-09-01") },
                new Student { FirstMidName = "Joseph",    LastName = "Smith",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Brigham",     LastName = "Young",
                    EnrollmentDate = DateTime.Parse("2015-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Richard",     LastName = "Fry",
                    HireDate = DateTime.Parse("2000-03-11") },
                new Instructor { FirstMidName = "Robert",    LastName = "Hilton",
                    HireDate = DateTime.Parse("1996-07-06") },
                new Instructor { FirstMidName = "Kyle",   LastName = "Feuz",
                    HireDate = DateTime.Parse("2008-07-01") },
                new Instructor { FirstMidName = "Bradley", LastName = "Peterson",
                    HireDate = DateTime.Parse("2008-01-15") },
                new Instructor { FirstMidName = "Yong",   LastName = "Zhang",
                    HireDate = DateTime.Parse("2014-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Web/UX",     Budget = 350000,
                    StartDate = DateTime.Parse("2016-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fry").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2016-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Hilton").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2016-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Peterson").ID },
                new Department { Name = "Computer Science",   Budget = 100000,
                    StartDate = DateTime.Parse("2016-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Zhang").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Physics for Engineers",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 1030, Title = "Foundations of Computer Science", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID
                },
                new Course {CourseID = 3100, Title = "Operating Systems", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID
                },
                new Course {CourseID = 1210, Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 1060, Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 1400, Title = "Intro to HTML",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Web/UX").DepartmentID
                },
                new Course {CourseID = 2650, Title = "Advanced CSS",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Web/UX").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fry").ID,
                    Location = "EH 383" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Peterson").ID,
                    Location = "Davis Building 2" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Hilton").ID,
                    Location = "TE 114K" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Physics for Engineers" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Hilton").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Physics for Engineers" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Peterson").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Feuz").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Hilton").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Intro to HTML" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Advanced CSS" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fry").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bigelow").ID,
                    CourseID = courses.Single(c => c.Title == "Intro to HTML" ).CourseID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bowen").ID,
                    CourseID = courses.Single(c => c.Title == "Advanced CSS" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Frazier").ID,
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Krause").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Wheeler").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Williams").ID,
                    CourseID = courses.Single(c => c.Title == "Physics for Engineers" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Smith").ID,
                    CourseID = courses.Single(c => c.Title == "Physics for Engineers" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Young").ID,
                    CourseID = courses.Single(c => c.Title == "Physics for Engineers").CourseID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bowen").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Frazier").ID,
                    CourseID = courses.Single(c => c.Title == "Intro to HTML").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Wheeler").ID,
                    CourseID = courses.Single(c => c.Title == "Intro to HTML").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}