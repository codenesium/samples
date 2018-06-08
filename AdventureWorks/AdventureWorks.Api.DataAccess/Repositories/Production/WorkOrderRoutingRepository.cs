using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class WorkOrderRoutingRepository: AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
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
    <Hash>0ef6ceaa4665f795f885c95c0ac25674</Hash>
</Codenesium>*/