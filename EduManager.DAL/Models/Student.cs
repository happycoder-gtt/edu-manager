using System;
using System.Collections.Generic;
using System.Text;

namespace EduManager.DAL.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Major { get; set; }
        public bool IsActive { get; set; }
    }
}
