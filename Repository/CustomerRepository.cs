using System.Collections.Generic;
using System.Linq;
using Assignment_NRDCL.Models;
using Assignment_NRDCL.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment_NRDCL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly NrdclDbContext _context;

        public CustomerRepository(NrdclDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Customer customer)
        {
            if (!IsIDExists(customer.CustomerCID))
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async void Remove(string id)
        {
            var customer = FindByID(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async void Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        public Customer FindByID(string id)
        {
            return _context.Customers.FirstOrDefaultAsync(m => m.CustomerCID == id).Result;
        }

        public List<Customer> FindAll()
        {
            return _context.Customers.ToList();
        }

        public bool IsIDExists(string id)
        {
            return _context.Customers.Any(e => e.CustomerCID == id);
        }

        public Customer FindByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsIDExists(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
