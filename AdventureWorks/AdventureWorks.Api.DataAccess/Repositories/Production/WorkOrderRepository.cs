using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class WorkOrderRepository : AbstractWorkOrderRepository, IWorkOrderRepository
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
    <Hash>60ac03d4ac58d6736a1e3f3a13c80fd0</Hash>
</Codenesium>*/