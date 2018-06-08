using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class WorkOrderRepository: AbstractWorkOrderRepository, IWorkOrderRepository
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
    <Hash>3b9c38ba3fc98236da2bb090e0c04b24</Hash>
</Codenesium>*/