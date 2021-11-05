using Core.Context;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        //private GenericRepository<Alert> alertRepository;

        //public GenericRepository<Alert> AlertRepository
        //{
        //    get
        //    {

        //        if (this.alertRepository == null)
        //        {
        //            this.alertRepository = new GenericRepository<Alert>(this.context);
        //        }
        //        return alertRepository;
        //    }
        //}

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            AlertRepository = new AlertRepository(this.context);
        }

        public IAlertRepository AlertRepository { get; private set; }


        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
