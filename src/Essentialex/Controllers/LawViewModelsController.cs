using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Essentialex.Models;
using Essentialex.ViewModels.Law;
using AutoMapper;
using System.Collections.Generic;



namespace Essentialex.Controllers
{
    public class LawViewModelsController : Controller
    {
        private ApplicationDbContext _context;

        public LawViewModelsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        [ActionName("Index")]
        public IActionResult Index(int? page, int? take)
        {
            int skip;

            if (page == null)
            {
                return View();
            }
            else{
                skip =  (int) page * 10;
                take = 10;
                return View(_context.LawViewModel.Skip(skip).Take((int)take).ToList().OrderBy(m => m.LawName));
            }
        }
        public IActionResult Search(int? page, int? take)
        {
            int skip;

            if (page == null)
            {
                return View();
            }
            else {
                skip = (int)page * 10;
                take = 10;
                return View(_context.LawViewModel.Skip(skip).Take((int)take).ToList().OrderBy(m => m.LawName));
            }
        }

        [HttpGet]
        public JsonResult SearchJson(int? page, int? take)
        {
            int skip;

            if (page == null)
            {
                return null;
            }
            else {

                JsonLaw LawObject = new JsonLaw();
                List<LawViewModel> model = new List<LawViewModel>();

                skip = (int)page * 10;
                take = 10;

                model = Mapper.Map <List<Law>,List<LawViewModel>>( _context.LawViewModel.Skip(skip).Take((int)take).OrderBy(m => m.LawName).ToList());

                LawObject.records = model;
                LawObject.hits = _context.LawViewModel.Count();

                return Json(LawObject);
            }
        }
        // GET: LawViewModels/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LawViewModel lawViewModel = Mapper.Map<Law, LawViewModel> (_context.LawViewModel.SingleOrDefault(m => m.Id == id));

            if (lawViewModel == null)
            {
                return HttpNotFound();
            }

            return View(lawViewModel);
        }

        // GET: LawViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LawViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LawViewModel lawViewModel)
        {
            if (ModelState.IsValid)
            {
                Law newLaw = Mapper.Map<LawViewModel, Law>(lawViewModel);

                _context.LawViewModel.Add(newLaw);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(lawViewModel);
        }

        // GET: LawViewModels/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LawViewModel lawViewModel = Mapper.Map < Law, LawViewModel >(_context.LawViewModel.Single(m => m.Id == id));
            if (lawViewModel == null)
            {
                return HttpNotFound();
            }
            return View(lawViewModel);
        }

        // POST: LawViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LawViewModel lawViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(lawViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lawViewModel);
        }

        // GET: LawViewModels/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LawViewModel lawViewModel = Mapper.Map<Law, LawViewModel>(_context.LawViewModel.Single(m => m.Id == id));

            if (lawViewModel == null)
            {
                return HttpNotFound();
            }

            return View(lawViewModel);
        }

        // POST: LawViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Law lawViewModel = _context.LawViewModel.Single(m => m.Id == id);

            _context.LawViewModel.Remove(lawViewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
public class JsonLaw
{
    public List<LawViewModel> records;
    public int hits;
}
