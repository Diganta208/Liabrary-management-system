using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Assign
    {
        public int Id { get; set; }
         [Display(Name = " Department Id")]
        public int DepartmentId { get; set; }

           [Display(Name = "Book Id")]
        public int BookId { get; set; }
         [Display(Name = "Student Id")]
        public int StudentId { get; set; }
         [Display(Name = "Issue Date")]
         public DateTime IssueDate { get; set; } 
    }
}