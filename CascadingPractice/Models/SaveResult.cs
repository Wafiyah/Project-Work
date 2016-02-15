using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingPractice.Models
{
    public class SaveResult
    {
        public int StudentId { get; set; }
    
        public string RegNo { get; set; }

        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public string Department { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Grade { get; set; }
        
    }
}