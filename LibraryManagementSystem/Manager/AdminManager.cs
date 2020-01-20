using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Gateway;

namespace LibraryManagementSystem.Manager
{
    public class AdminManager
    {
        AdminGateWay aAdminGateWay = new AdminGateWay();

         public int Save(Assign aAssignBook)
        {
            return aAdminGateWay.Save(aAssignBook);
        }

         public List<Books> GetBookByDepartmentId(int DepartmentId)
         {
             return aAdminGateWay.GetBookByDepartmentId(DepartmentId);
         }

        public Student StudentInformation(string StudentId)
         {
             return aAdminGateWay.StudentInformation(StudentId);
         }
          public int SaveRecieveBookInfo(RecieveBook aRecieveBook)
         {
             Assign aAssignBook = aAdminGateWay.AssignBookInformation(aRecieveBook.StudentId, aRecieveBook.BookId);
             TimeSpan dif = aRecieveBook.RecieveDate - aAssignBook.IssueDate;

             double nodays = dif.TotalDays;
             if (nodays>14)
             {
                 int newDif= Convert.ToInt32(nodays-14);
                 aRecieveBook.LateFee = newDif * 2;
             }
             else
             {
                 aRecieveBook.LateFee = 0;
             }
             return aAdminGateWay.SaveRecieveBookInfo(aRecieveBook);

         }

          public Admin AdminInformation(string AdminId)
          {
              return aAdminGateWay.AdminInformation(AdminId);
          }

         public bool IsAdminExsists(string AdminId)
          {
              return aAdminGateWay.IsAdminExsists(AdminId);
          }
    }
}