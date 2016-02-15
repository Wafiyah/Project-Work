using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingPractice.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double Credit { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public int Semester { get; set; }
        public int DepartmentId { get; set; }
    }
}