using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
         [Display(Name = "Student Id ")]
        public string StudentId { get; set; }
        [Display(Name = "Department ")]
        public int DepartmentId { get; set; }
    }
}