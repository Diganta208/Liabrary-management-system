using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;

namespace LibraryManagementSystem.Gateway
{
    public class StudentGateWay
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public StudentGateWay()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["LibrryDBconneCtionString"].ConnectionString;
            Connection = new SqlConnection(connectionString);
        }

        public List<BookDetailsViewModel> GetAllBooks()
        {
            string query = "SELECT * FROM Books AS b INNER JOIN Department AS d ON b.DepartmentId=d.Id";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<BookDetailsViewModel> BookList = new List<BookDetailsViewModel>();
            while (Reader.Read())
            {
                BookDetailsViewModel aBooks = new BookDetailsViewModel();
                aBooks.Id = Convert.ToInt32(Reader["Id"]);
                aBooks.BookName = Reader["BookName"].ToString();
                aBooks.BookId = Reader["BookId"].ToString();
                aBooks.AuthorName = Reader["AuthorName"].ToString();
                aBooks.DepartmentName = Reader["DepartmentName"].ToString();
                aBooks.Price = Convert.ToInt32(Reader["Price"]);
                aBooks.Quantity = Convert.ToInt32(Reader["Quantity"]); 


                BookList.Add(aBooks);
            }
            Connection.Close();
            return BookList;
        }

        public int Save(Student aStudent)
        {
            string query = "INSERT INTO Student VALUES(@Name,@StudentId,@DepartmentId)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Name", aStudent.Name);
            Command.Parameters.AddWithValue("@StudentId", aStudent.StudentId);
            Command.Parameters.AddWithValue("@DepartmentId", aStudent.DepartmentId);
           

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsStudentExsists(string StudentId)
        {

            string query = "SELECT * FROM Student WHERE StudentId='" + StudentId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }


    }
}