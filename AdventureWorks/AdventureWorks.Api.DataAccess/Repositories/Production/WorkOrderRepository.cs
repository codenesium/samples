using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class WorkOrderRepository : AbstractWorkOrderRepository, IWorkOrderRepository
        {
                public WorkOrderRepository(
                        ILogger<WorkOrderRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0913e4cc6f73b15caa041d131ef67694</Hash>
</Codenesium>*/