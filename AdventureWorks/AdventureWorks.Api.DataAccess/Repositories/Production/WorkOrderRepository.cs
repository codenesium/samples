using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>52881ad97c600d68c8f6a71ec1d4bf2d</Hash>
</Codenesium>*/