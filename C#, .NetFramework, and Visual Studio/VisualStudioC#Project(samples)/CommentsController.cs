using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

//Controller and associated views created by the Entity Framework MVC CRUD option in Visual Studio
namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/Comments
        public ActionResult Index()
        {
            return View();
        }
        //The method above was simplified. Now the Index view page will call the method below "CommentsPartial()

        public ActionResult CommentsPartial()
        {
            return PartialView("_Comments", db.Comments.ToList());
        }
        //This method links to a partial view called _Comments which takes the Comments data from the database and displays it according to the html in the partial view.
        //Seperating it from the Index() and Index view makes it more easily accesible to other parts of the program.