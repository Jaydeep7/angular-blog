using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransferDataFromControllerToView.Models;

namespace TransferDataFromControllerToView.Models
{
    public class Repository
    {
        public List<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course { CourseId =1 ,CourseName ="B.C.A." },
                new Course { CourseId =2,CourseName ="B.B.A." },
                new Course { CourseId =3, CourseName ="B.COM." },
                new Course { CourseId =4,CourseName ="P.T.C." }
            };
        }

        public List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, StduentName = "jaydep karena",
                                     EnrolledCourses =   new List<Course>
                                        {
                                            new Course { CourseId = 1, CourseName = "B.C.A." },
                                            new Course { CourseId = 2, CourseName = "B.B.A." }
                                        }
                            },
                new Student { StudentId = 2, StduentName = "Viajy Rathod",
                                     EnrolledCourses =   new List<Course>
                                        {
                                            new Course { CourseId = 3, CourseName = "B.COM." },
                                            new Course { CourseId = 2, CourseName = "B.B.A." }
                                        }
                            },
                new Student { StudentId = 3, StduentName = "nayan patel",
                                     EnrolledCourses =   new List<Course>
                                        {
                                            new Course { CourseId = 1, CourseName = "B.C.A." },
                                            new Course { CourseId = 4, CourseName = "P.T.C." }
                                        }
                            }

            };
        }

        public List<Faculty> GetFaculties()
        {
            return new List<Faculty>
            {
                new Faculty { FacultyId = 1, FacultyName = "Aspi Ambapardiwala",
                                AllotedCourses  =  new List<Course>
                                {
                                     new Course { CourseId = 3, CourseName = "B.COM." },
                                     new Course { CourseId = 2, CourseName = "B.B.A." }
                                }
                            },
                new Faculty { FacultyId = 2, FacultyName = "Parsi",
                                AllotedCourses  =  new List<Course>
                                {
                                     new Course { CourseId = 1, CourseName = "B.C.A." },
                                     new Course { CourseId = 4, CourseName = "P.T.C." }
                                }
                            },

                new Faculty { FacultyId = 3, FacultyName = "Popat",
                                AllotedCourses  =  new List<Course>
                                {
                                     new Course { CourseId = 1, CourseName = "B.C.A." },
                                     new Course { CourseId = 2, CourseName = "B.B.A." }
                                }
                            }

            };
        }
    }
}