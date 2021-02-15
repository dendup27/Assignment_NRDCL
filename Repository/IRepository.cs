using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_NRDCL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Add(T item);
        void Remove(string id);
        void Remove(int id);
        void Update(T item);
        T FindByID(string id);
        T FindByID(int id);
        List<T> FindAll();
        bool IsIDExists(string id);
        bool IsIDExists(int id);
    }
}
