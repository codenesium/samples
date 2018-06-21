using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class WorkOrderService : AbstractWorkOrderService, IWorkOrderService
        {
                public WorkOrderService(
                        ILogger<IWorkOrderRepository> logger,
                        IWorkOrderRepository workOrderRepository,
                        IApiWorkOrderRequestModelValidator workOrderModelValidator,
                        IBOLWorkOrderMapper bolworkOrderMapper,
                        IDALWorkOrderMapper dalworkOrderMapper,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper
                        )
                        : base(logger,
                               workOrderRepository,
                               workOrderModelValidator,
                               bolworkOrderMapper,
                               dalworkOrderMapper,
                               bolWorkOrderRoutingMapper,
                               dalWorkOrderRoutingMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>161f77e92932fefa9d51da92d2f51b17</Hash>
</Codenesium>*/