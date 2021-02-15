using System.Collections.Generic;
using System.Linq;
using Assignment_NRDCL.Models;
using Assignment_NRDCL.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment_NRDCL.Repository
{
    public class SiteRepository : IRepository<Site>
    {
        private readonly NrdclDbContext _context;
        private readonly IRepository<Customer> customerRepository;

        public SiteRepository(NrdclDbContext context, IRepository<Customer> customerRepository)
        {
            _context = context;
            this.customerRepository = customerRepository;
        }

        public async Task<bool> Add(Site site)
        {
            if (customerRepository.IsIDExists(site.CustomerID))
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async void Remove(int id)
        {
            var site = FindByID(id);
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
        }

        public async void Update(Site site)
        {
            _context.Update(site);
            await _context.SaveChangesAsync();
        }

        public Site FindByID(int id)
        {
            return _context.Sites.FirstOrDefaultAsync(m => m.SiteID == id).Result;
        }

        public List<Site> FindAll()
        {
            var customer = customerRepository.FindAll();
            return _context.Sites.ToList();
        }

        public bool IsIDExists(int id)
        {
            return _context.Sites.Any(e => e.SiteID == id);
        }

        public Customer FindByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new System.NotImplementedException();
        }

        Site IRepository<Site>.FindByID(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsIDExists(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}

