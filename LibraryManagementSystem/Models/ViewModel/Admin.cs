using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Display(Name = " Admin Id")]
        public string AdminId { get; set; }
        [Display(Name = " Password")]
        public string Password { get; set; }
    }
}