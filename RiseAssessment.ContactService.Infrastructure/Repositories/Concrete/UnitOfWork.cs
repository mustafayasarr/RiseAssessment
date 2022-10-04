using Microsoft.EntityFrameworkCore.Storage;
using RiseAssessment.ContactService.Infrastructure.Context;
using RiseAssessment.ContactService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Infrastructure.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbContextTransaction transaction = null;
        ContactDbContext _context;
        public UnitOfWork(ContactDbContext context)
        {
            _context = context;
            ContactRepository = new ContactRepository(_context);
            ContactInformationRepository = new ContactInformationRepository(_context);
    

            transaction = context.Database.BeginTransaction();
        }
        public IContactRepository ContactRepository { get; }
        public IContactInformationRepository ContactInformationRepository { get; }
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
