using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Infrastructure.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }
        IContactInformationRepository ContactInformationRepository { get; }
        void Complete(bool state = true);
        Task CompleteAsync(bool state = true);
    }
}
