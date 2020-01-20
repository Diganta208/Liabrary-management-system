using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Manager;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentManger aStudentManger = new StudentManger();
        BookManager aBookManager = new BookManager();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            ViewBag.Departments = aBookManager.GetAllDepartment();
            return View();
        }

        public ActionResult BookDetails()
        {
            ViewBag.BookList = aStudentManger.GetAllBooks();
           
            return View();
        }

        [HttpGet]
        public ActionResult SaveStudent()
        {
            ViewBag.Departments = aBookManager.GetAllDepartment(); 
            return View();
        }


       

        [HttpPost]
        public ActionResult SaveStudent(Student aStudent)
        {

            if (aStudentManger.IsStudentExsists(aStudent.StudentId))
            {
                ViewBag.Message = "Stududent already exist";
            }
            else
            {
                ViewBag.Departments = aBookManager.GetAllDepartment();
                int rowAffect = aStudentManger.Save(aStudent);
                if (rowAffect > 0)
                {
                    ViewBag.Message = "Successful";
                }
                else
                {
                    ViewBag.Message = "Filed";
                }
            }
           

            return View();
        }
	}
}