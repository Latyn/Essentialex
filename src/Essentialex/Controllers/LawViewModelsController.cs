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

        // GET: LawViewModels
        public IActionResult Index()
        {
            return View(_context.LawViewModel.ToList().OrderBy(m => m.LawName));
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
