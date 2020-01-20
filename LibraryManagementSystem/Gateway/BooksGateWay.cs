using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystem.Models;


namespace LibraryManagementSystem.Gateway
{
    public class BooksGateWay
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public BooksGateWay()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["LibrryDBconneCtionString"].ConnectionString;
            Connection = new SqlConnection(connectionString);
        }

        public List<Department> GetAllDepartment()
        {
            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> DepartmentList = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = Convert.ToInt32(Reader["Id"]);
                aDepartment.DepartmentName = Reader["DepartmentName"].ToString();
                 aDepartment.ShortName = Reader["ShortName"].ToString();
                DepartmentList.Add(aDepartment);
            }
            Connection.Close();
            return DepartmentList;
        }

        public int Save(Books aBook)
        {
            string query = "INSERT INTO Books VALUES(@BookName,@BookId,@AuthorName,@DepartmentId,@Quantity,@Price)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@BookName", aBook.BookName);
            Command.Parameters.AddWithValue("@BookId", aBook.BookId);
            Command.Parameters.AddWithValue("@AuthorName", aBook.AuthorName);
            Command.Parameters.AddWithValue("@DepartmentId", aBook.DepartmentId);
            Command.Parameters.AddWithValue("@Quantity", aBook.Quantity);
            Command.Parameters.AddWithValue("@Price", aBook.Price);
            
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public Books GetBookInfo(string aBookId)
        {
            string query = "SELECT Id,BookId,Quantity FROM Books WHERE BookId='" + aBookId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Books aBook = new Books();
            if(Reader.HasRows)
            {
               
                aBook.BookId = Reader["BookId"].ToString();
                aBook.Quantity = Convert.ToInt32(Reader["Quantity"]);
                aBook.Id = Convert.ToInt32(Reader["Id"]);
            }
            
            
           
            Connection.Close();
            return aBook;
        }


        public bool IsBookExsists(string aBookId)
        {

            string query = "SELECT * FROM Books WHERE BookId='" + aBookId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

         public int UpdateBook(int quantity, int Id)
        {

            string query = "UPDATE Books SET Quantity='" + quantity + "' WHERE Id=" +Id+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
 }

