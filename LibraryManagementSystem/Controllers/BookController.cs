using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Manager;
using LibraryManagementSystem.Models;


namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        BookManager aBookManager = new BookManager();
        //
        // GET: /Book/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addBook()
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
        public ActionResult addBook(Books aBook)
        {
            ViewBag.Departments = aBookManager.GetAllDepartment();
            int rowAffect = aBookManager.Save(aBook);
            if (rowAffect>0)
            {
                ViewBag.Message = "Successful";
            }
            else
            {
                ViewBag.Message = "Filed";
            }

            return View();
        }
	}
}