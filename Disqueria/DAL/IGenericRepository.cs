using System.Collections.Generic;

namespace Disqueria.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetID(int id);
        bool Add(T model);
        bool Update(T model);
        bool Del(int id);
        void Save();

    }
}