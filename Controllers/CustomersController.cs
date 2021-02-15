using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_NRDCL.Models;
using Assignment_NRDCL.Repository;

namespace Assignment_NRDCL.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomersController(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(customerRepository.FindAll());
        }

        // GET: Customers/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepository.FindByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerCID,CustomerName,Mobile,MailId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customerRepository.Add(customer).Result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("CustomerCID", "Customer CID number already registered. Please enter different CID number.");
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepository.FindByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("CustomerCID,CustomerName,Mobile,MailId")] Customer customer)
        {
            if (id != customer.CustomerCID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customerRepository.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!customerRepository.IsIDExists(customer.CustomerCID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepository.FindByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            customerRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
