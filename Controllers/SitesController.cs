using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_NRDCL.Models;
using Assignment_NRDCL.Repository;

namespace Assignment_NRDCL.Controllers
{
    public class SitesController : Controller
    {
        private readonly IRepository<Site> siteRepository;

        public SitesController(IRepository<Site> siteRepository)
        {
            this.siteRepository = siteRepository;
        }

        // GET: Sites
        public IActionResult Index()
        {
            ViewData["Title"] = "Create dddd";
            return View(siteRepository.FindAll());
        }

        // GET: Sites/Details/5
        public IActionResult Details(int id)
        {
            var site = siteRepository.FindByID(id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SiteID,CustomerID,SiteName,Distance")] Site site)
        {
            if (ModelState.IsValid)
            {
                if (siteRepository.Add(site).Result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("CustomerID", "Please enter a registered CID number.");
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public IActionResult Edit(int id)
        {
            var site = siteRepository.FindByID(id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Sites/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SiteID,CustomerID,SiteName,Distance")] Site site)
        {
            if (id != site.SiteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    siteRepository.Update(site);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!siteRepository.IsIDExists(site.SiteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Delete/5
        public IActionResult Delete(int id)
        {
            var site = siteRepository.FindByID(id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            siteRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
