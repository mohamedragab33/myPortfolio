using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
   public class GenircRepository<T> : IGenricRepository<T> where T  : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> table;
        public GenircRepository(AppDbContext context)
          {
            _context = context;
            table = _context.Set<T>();
        }
         
        public void delete(object id)
        {
            T exist = GetById(id);
            table.Remove(exist);
             
        }

        public IEnumerable<T> GetAll()
        {
        return  table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void insert(T entity)
        {
            table.Add(entity);
        }

        public void update(T entity)
        {

            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
