using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IGenricRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void insert(T entity);

        void update(T entity);



        void delete(object id);

    }
}
