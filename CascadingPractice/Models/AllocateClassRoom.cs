using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CascadingPractice.Models
{
    public class AllocateClassRoom
    {
        public int DepartmentId { get; set; }

        public int CourseId { get; set; }

        public int RoomId { get; set; }

        public string Day { get; set; }

        public bool isDeleted { get; set; }

        public string StartTime { get; set; }

        public string FromAmPm { get; set; }

        public string EndTime { get; set; }

        public string ToAmPm { get; set; }

        public string DepartmentName { get; set; }

        public string CourseName { get; set; }

        public string RoomName { get; set; }

        public TimeSpan STime { get; set; }

        public TimeSpan ETime { get; set; }

    }
}