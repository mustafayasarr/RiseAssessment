using Microsoft.EntityFrameworkCore.Storage;
using RiseAssessment.ReportService.Infrastructure.Context;
using RiseAssessment.ReportService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Infrastructure.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbContextTransaction transaction = null;
        ContactDbContext _context;
        public UnitOfWork(ContactDbContext context)
        {
            _context = context;


            transaction = context.Database.BeginTransaction();
        }

        public void Complete(bool state = true)
        {
            _context.SaveChanges();
            if (state)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
            Dispose();
        }

        public async Task CompleteAsync(bool state = true)
        {
            await _context.SaveChangesAsync();
            if (state)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
            Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
