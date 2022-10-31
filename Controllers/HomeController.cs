using DobLabASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DobLabASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Moning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        public IActionResult ContactsList(string? group = null)
        {
            List<Contact>? c = null;
            using (ContactsContext db = new ContactsContext())
            {
                if (group == null)
                    ViewBag.Contacts = db.Contacts.ToList();
                else if (group == "All")
                    c = db.Contacts.ToList();
                else
                    c = db.Contacts.Where((e) => e.Group == group).ToList();
            }
            if (group == null)
                return View();
            else
                return Json(c);
        }



        [HttpPost]
        public IActionResult FormContact(Contact contact)
        {
            using (ContactsContext db = new ContactsContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return View("ContactAdded", contact);
        }


    }

}