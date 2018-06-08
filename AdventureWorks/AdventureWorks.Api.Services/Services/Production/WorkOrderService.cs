using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class WorkOrderService: AbstractWorkOrderService, IWorkOrderService
        {
                public WorkOrderService(
                        ILogger<WorkOrderRepository> logger,
                        IWorkOrderRepository workOrderRepository,
                        IApiWorkOrderRequestModelValidator workOrderModelValidator,
                        IBOLWorkOrderMapper bolworkOrderMapper,
                        IDALWorkOrderMapper dalworkOrderMapper)
                        : base(logger,
                               workOrderRepository,
                               workOrderModelValidator,
                               bolworkOrderMapper,
                               dalworkOrderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c0898046e69e77a950cf8188b8956c1d</Hash>
</Codenesium>*/