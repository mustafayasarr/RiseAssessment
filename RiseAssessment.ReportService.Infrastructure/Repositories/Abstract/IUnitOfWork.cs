using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Infrastructure.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {

        void Complete(bool state = true);
        Task CompleteAsync(bool state = true);
    }
}
