using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class WorkOrderRoutingRepository : AbstractWorkOrderRoutingRepository, IWorkOrderRoutingRepository
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
    <Hash>b70a70a53bc7d4a0a018579ecf430600</Hash>
</Codenesium>*/