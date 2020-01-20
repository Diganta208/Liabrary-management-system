using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Manager;

namespace LibraryManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        AdminManager aAdminManager = new AdminManager();
        BookManager aBookManager = new BookManager();

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Assign()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Departments = aBookManager.GetAllDepartment();
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult Assign(Assign  aAssignBook , string student)
        {
            ViewBag.Departments = aBookManager.GetAllDepartment();
            Student aStudent = aAdminManager.StudentInformation(student);
            aAssignBook.StudentId = aStudent.Id;
            int rowAffect = aAdminManager.Save(aAssignBook);
            if (rowAffect > 0)
            {
                ViewBag.Message = "Successful";
            }
            else
            {
                ViewBag.Message = "Filed";
            }
            return View();
        }


        [HttpGet]
        public ActionResult RecieveBook()
        {
            if (Session["AdminId"]==null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Departments = aBookManager.GetAllDepartment();
                return View();

            }
           
        }


         [HttpPost]
        public ActionResult RecieveBook(RecieveBook aRecieveBook, string student)
        {
            ViewBag.Departments = aBookManager.GetAllDepartment();
            Student aStudent = aAdminManager.StudentInformation(student);
            aRecieveBook.StudentId = aStudent.Id;
            int rowAffect = aAdminManager.SaveRecieveBookInfo(aRecieveBook);
            if (rowAffect > 0)
            {
                ViewBag.Message = "Successful";
            }
            else
            {
                ViewBag.Message = "Filed";
            }
            
            return View();
        }

        [HttpGet]
         public ActionResult LogIn()
         {
             return View();
         }
         [HttpPost]
        public ActionResult LogIn(Admin aAdmin)
        {
            if (aAdminManager.IsAdminExsists(aAdmin.AdminId))
             {
                 Admin nAdmin = aAdminManager.AdminInformation(aAdmin.AdminId);
                 if (nAdmin.AdminId == aAdmin.AdminId && nAdmin.Password == aAdmin.Password)
                 {
                     Session["AdminId"] = nAdmin.Id;
                     return RedirectToAction("Assign", "Admin");
                 }
                 else
                 {
                     ViewBag.Message = "Filed";
                     return View();
                 }
             }

            else
            {
                ViewBag.Message = "This Admin does not exist";
                return View();
            }
           
            
        }

        public JsonResult GetBookByDepartmentId(int DepartmentId)
        {
            List<Books> book = aAdminManager.GetBookByDepartmentId(DepartmentId);
            ViewBag.book = book;
            return Json(book);
       }
	}
}