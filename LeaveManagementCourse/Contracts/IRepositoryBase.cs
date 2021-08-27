using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementCourse.Contracts
{
    public interface IRepositoryBase<T> where T : class // making this interface generic so that we can pass any class and perform operations on it
    {
        ICollection<T> FindAll(); // ICollection is a generic collection (it is like array i can accept an array of any objects)
        T FindById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
