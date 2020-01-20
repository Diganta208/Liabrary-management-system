using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Gateway
{
    public class AdminGateWay
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public AdminGateWay()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["LibrryDBconneCtionString"].ConnectionString;
            Connection = new SqlConnection(connectionString);
        }

        public int Save(Assign aAssignBook)
        {
            string query = "INSERT INTO Assign VALUES(@StudentId, @BookId, @DeprtmentId, @IssueDate)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", aAssignBook.StudentId);
            Command.Parameters.AddWithValue("@IssueDate", aAssignBook.IssueDate);
           

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }


        public int SaveRecieveBookInfo(RecieveBook aRecieveBook)
        {
            string query = "INSERT INTO RecieveBook VALUES(@StudentId, @BookId, @DepartmentId, @RecieveDate, @LateFee)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", aRecieveBook.StudentId);
            Command.Parameters.AddWithValue("@BookId", aRecieveBook.BookId);
            Command.Parameters.AddWithValue("@DepartmentId", aRecieveBook.DepartmentId);
            Command.Parameters.AddWithValue("@RecieveDate", aRecieveBook.RecieveDate);
            Command.Parameters.AddWithValue("@LateFee", aRecieveBook.LateFee);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public Assign AssignBookInformation(int StudentId, int BookId)
        {
            string query = "SELECT * FROM Assign WHERE BookId='" + BookId + "' AND StudentId='" + StudentId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Assign aAssignBook = new Assign();
            if (Reader.HasRows)
            {
                aAssignBook.IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
            }

            Connection.Close();
            return aAssignBook;
        }

        public Admin AdminInformation(string AdminId)
        {
            string query = "SELECT * FROM Admin WHERE AdminId='" + AdminId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Admin aAdmin = new Admin();
            if (Reader.HasRows)
            {
                aAdmin.Id = Convert.ToInt32(Reader["Id"]);
                aAdmin.AdminId = Reader["AdminId"].ToString();
                aAdmin.Password = Reader["Password"].ToString();
            }

            Connection.Close();
            return aAdmin;
        }

        public bool IsAdminExsists(string AdminId)
        {

            string query = "SELECT * FROM Admin WHERE AdminId='" + AdminId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }


        public Student StudentInformation(string StudentId)
        {
            string query = "SELECT * FROM Student WHERE StudentId='" + StudentId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Student aStudent = new Student();
            if (Reader.HasRows)
            {
                aStudent.Id = Convert.ToInt32(Reader["Id"]);
                aStudent.StudentId = Reader["StudentId"].ToString();
            }

            Connection.Close();
            return aStudent;
        }
        public List<Books> GetBookByDepartmentId(int DepartmentId)
        {
            string query = "SELECT * FROM Books  WHERE DepartmentId='" + DepartmentId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Books> bookList = new List<Books>();
            while (Reader.Read())
            {
                Books aBook = new Books();
                aBook.Id = Convert.ToInt32(Reader["Id"]);
                aBook.BookId = Reader["BookId"].ToString();
                bookList.Add(aBook);
            }
            Connection.Close();
            return bookList;
        }
    }
}