using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCNotes.Models;
using MVCNotes.Views.Home;
using System.Text;

namespace MVCNotes.Controllers
{
    public class NotesController : Controller
    {
        private NotesDBEntities db = new NotesDBEntities();

        // GET: Notes
        [HttpGet]
        public ActionResult AllNotes()
        {
            //return View("AllNotes","_Layout", db.Notes); call with custom layout page
            return View("AllNotes",  db.Notes);
        }

        [HttpPost]
        public ActionResult AllNotes(int button1)
        {
            Notes updNote = db.Notes.Single(x => x.Id == button1);
            updNote.Completed = updNote.Completed == true ? false : true;
            db.SaveChanges();
            return View(db.Notes);
        }

        [HttpGet]
        public ActionResult NewNote()
        {
            Notes notes = new Notes();
            return View(notes);
        }

        [HttpPost]
        public ActionResult NewNote(Notes note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
            return RedirectToAction("AllNotes", "Notes");
        }

        [HttpGet]
        public ActionResult EditNotes()
        {
            List<Notes> notes = db.Notes.ToList();
            return View(notes);
        }

        [HttpPost]
        public string EditNotes(IEnumerable<Notes> notes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Notes note in notes)
            {
                if (note.Completed == true)
                {
                    sb.Append(note.Description).AppendLine();
                }
            }
            return sb.ToString();
        }
    }
}