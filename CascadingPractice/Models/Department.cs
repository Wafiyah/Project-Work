using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CascadingPractice.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Code is Required")]
        [DisplayName("Code")]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Code must be two (2) to seven (7) character long ")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [DisplayName("Name")]
        public string DepartmentName { get; set; }
    }
}