using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UOPO.Models;
using System.Data.Entity;

namespace UOPO.Controllers
{
    public class AdventuresController : Controller
    {
        private ApplicationDbContext _context;
        
        public AdventuresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Adventures
        public ActionResult Index()
        {
            var adventure = _context.Adventures.ToList();
            //var adventure = _context.Adventures.Include(c => c.EncounterId).ToList();
            return View(adventure);
        }

        public ActionResult Details(int id)
        {
            var adventure = _context.Adventures.SingleOrDefault(c => c.Id == id);

            if (adventure == null)
                return HttpNotFound();
            return View(adventure);
        }
    }
}