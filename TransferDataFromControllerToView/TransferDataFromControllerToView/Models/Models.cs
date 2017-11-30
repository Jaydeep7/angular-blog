using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransferDataFromControllerToView.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StduentName { get; set; }
        public List<Course> EnrolledCourses { get; set; }
    }

    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Course> AllotedCourses { get; set; }
    }
}