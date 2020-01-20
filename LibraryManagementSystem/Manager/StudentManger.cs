using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Gateway;
using LibraryManagementSystem.Models.ViewModel;


namespace LibraryManagementSystem.Manager
{
    public class StudentManger
    {
        StudentGateWay aStudentGateWay = new StudentGateWay();
           public List<BookDetailsViewModel> GetAllBooks()
        {
            return aStudentGateWay.GetAllBooks();
        }

          public int Save(Student aStudent)
           {
               return aStudentGateWay.Save(aStudent);
           }

           public bool IsStudentExsists(string StudentId)
          {
              return aStudentGateWay.IsStudentExsists(StudentId);
          }
    }
}