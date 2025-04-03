using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JamesBondGadgetsEntity;
using JamesBondGadgetsEntity.Models;

namespace JamesBondGadgetsEntity.Controllers
{
    public class GadgetsController : Controller
    {
        private ApplicationDbContext context;

        public GadgetsController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Gadgets
        public ActionResult Index()
        {
            List<GadgetsModel> gadgets = context.Gadgets.ToList();

            return View("Index", gadgets);
        }

        public ActionResult Details(int id)
        {
            GadgetsModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == id);
            return View("Details", gadgets);
        }

        public ActionResult Create()
        {
            return View("GadgetForm", new GadgetsModel());
        }

        public ActionResult Edit(int id)
        {
            GadgetsModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == id);

            return View("GadgetForm", gadgets);
        }

        public ActionResult Delete(int id)
        {

            GadgetsModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == id);

            context.Entry(gadgets).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();

            return View("Deleteq");
        }
        public ActionResult ProcessCreate(GadgetsModel gadgetsModel)
        {
            GadgetsModel gadgets = context.Gadgets.SingleOrDefault(g => g.Id == gadgetsModel.Id);

            //edit
            if(gadgets != null)
            {
                gadgets.Name = gadgetsModel.Name;
                gadgets.Description = gadgetsModel.Description;
                gadgets.AppearsIn = gadgetsModel.AppearsIn;
                gadgets.WithThisActor = gadgetsModel.WithThisActor;

               
            }
            //create
            else
            {
                context.Gadgets.Add(gadgetsModel);
            }
            context.SaveChanges();

            return View("Details", gadgetsModel);
        }
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {
            var gadgets = from g in context.Gadgets where g.Name.Contains(searchPhrase) select g;

            return View("Index", gadgets);
        }
    }
}