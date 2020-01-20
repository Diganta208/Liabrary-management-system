using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models.ViewModel
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        
        public string BookName { get; set; }
        
        public string BookId { get; set; }
       
        public string AuthorName { get; set; }

        public string DepartmentName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; } 
    }
}