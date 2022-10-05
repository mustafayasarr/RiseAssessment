using RiseAssessment.ReportService.Domain.Models.Entities;
using RiseAssessment.ReportService.Infrastructure.Context;
using RiseAssessment.ReportService.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ReportService.Infrastructure.Repositories.Concrete
{
    public class ReportItemRepository : Repository<ReportItem>, IReportItemRepository
    {
        public ReportItemRepository(ContactDbContext dbContext) : base(dbContext)
        {
        }
    }
}
