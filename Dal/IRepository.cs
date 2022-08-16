using System.Linq;

namespace Dal
{
    interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        T Update(T item1, T item2);
        IQueryable<T> GetAll();
    }
}