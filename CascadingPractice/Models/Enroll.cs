using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CascadingPractice.Models
{
    public class Enroll
    {
        
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        
        public string RegNo { get; set; }

        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public string StudentDepartment { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int DepartmentId { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EnrollDate { get; set; }

       


    }
}