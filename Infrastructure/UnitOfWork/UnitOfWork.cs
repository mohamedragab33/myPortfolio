using Core.Interfaces;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
  public  class UnitOfWork<T> : IUnitOfWorkRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private IGenricRepository<T> _entity;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public IGenricRepository<T> entity  {

            get {

                return _entity ?? (_entity =new GenircRepository<T>(context) );
            
            }
        
        
        }

        public void save()
        {
            context.SaveChanges();
        }
    }
}
