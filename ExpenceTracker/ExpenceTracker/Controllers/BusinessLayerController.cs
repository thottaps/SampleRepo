using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessAccessLayer;

namespace ExpenceTracker.Controllers
{
    public class BusinessLayerController : Controller
    {
        // GET: BusinessLayer
        public ActionResult Index()
        {
            ExpencesBusinessLayer ebl = new ExpencesBusinessLayer();
            List<Expences> expences = ebl.ExpencesList.ToList();
            return View(expences);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ExpencesBusinessLayer expencesBusinessLayer = new ExpencesBusinessLayer();
            Expences expence = expencesBusinessLayer.ExpencesList.Single(exp => exp.ExpenceID == id);

            return View(expence);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            Expences expences = new Expences();
            TryUpdateModel<Expences>(expences);
            //Expences expences = new Expences();
            //expences.ExpenceTypeID = Convert.ToInt16(formCollection["ExpenceType"]);
            //expences.ExpenceAmt = Convert.ToDecimal(formCollection["ExpenceAmt"]);
            //expences.ExpenceDescription = formCollection["ExpenceDescription"];
            //expences.ExpenceDate = Convert.ToDateTime(formCollection["ExpenceDate"]);
            if (ModelState.IsValid)
            {
                ExpencesBusinessLayer expencesBAL = new ExpencesBusinessLayer();
                expencesBAL.AddExpence(expences);
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult CreateExpenceType()
        {
            return View();
        }

        public ActionResult ExpenceType()
        {
            ExpencesBusinessLayer ebl = new ExpencesBusinessLayer();
            List<ExpencesType> expencestype = ebl.ExpencesType.ToList();
            return View(expencestype);
        }

    }
}