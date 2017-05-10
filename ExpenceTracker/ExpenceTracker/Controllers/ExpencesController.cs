using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenceTracker.Models;

namespace ExpenceTracker.Controllers
{
    public class ExpencesController : Controller
    {
        // GET: Expences
        public ActionResult ExpenceDetails()
        {
            ExpencesContext expence = new ExpencesContext();
            List<Expences> expences = expence.Expences.ToList();
            return View(expences);
        }
        public ActionResult SingleExpenceDetails(string ID)
        {
            ExpencesContext expence = new ExpencesContext();
            Expences expences = expence.Expences.Single(exp => exp.ExpenceID.Equals(ID));
            return View(expences);
        }
    }
}