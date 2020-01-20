using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Books
    {
        public int Id { get; set; }
       [Display(Name = "Book Name")]
        [Required]
        public string BookName { get; set; }
         [Display(Name = "Book Id")]
        [Required]
        public string BookId { get; set; }
         [Display(Name = "Author Name")]
         public string AuthorName { get; set; }
        [Display(Name = "Department")]
        [Required]
         public int DepartmentId { get; set; }
        [Required]
        public int Quantity { get; set; }
         [Required]
        public float Price { get; set; } 
    }
}