using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class WorkOrderRoutingRepository : AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
        {
                public WorkOrderRoutingRepository(
                        ILogger<WorkOrderRoutingRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>de74293552c3108b8540a9f824c8f631</Hash>
</Codenesium>*/