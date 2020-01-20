using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Gateway;

namespace LibraryManagementSystem.Manager
{
    public class BookManager
    {
        BooksGateWay aBooksGateWay = new BooksGateWay();
         public List<Department> GetAllDepartment()
        {
            return aBooksGateWay.GetAllDepartment();
        }
          public int Save(Books aBook)
         {
             if (aBooksGateWay.IsBookExsists(aBook.BookId))
             {
                 Books previousBookInfo = aBooksGateWay.GetBookInfo(aBook.BookId);
                 int newQuantity = previousBookInfo.Quantity + aBook.Quantity;
                 return aBooksGateWay.UpdateBook(newQuantity, previousBookInfo.Id);
             }
             else
             {
                 return aBooksGateWay.Save(aBook);
             }
            
         }
    }
}