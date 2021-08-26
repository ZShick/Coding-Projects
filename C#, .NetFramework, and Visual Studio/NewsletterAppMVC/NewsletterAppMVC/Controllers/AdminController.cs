using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList();
                var signups = (from c in db.SignUps
                               where c.Removed == null
                               select c).ToList();
                var signUpVms = new List<SignUpVm>();
                foreach (var signup in signups)
                {
                    var signUpVm = new SignUpVm();
                    signUpVm.Id = signup.Id;
                    signUpVm.FirstName = signup.FirstName;
                    signUpVm.LastName = signup.LastName;
                    signUpVm.EmailAddress = signup.EmailAddress;
                    signUpVms.Add(signUpVm);
                }

                return View(signUpVms);
            }
        }
        public ActionResult Unsubscribe(int Id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}