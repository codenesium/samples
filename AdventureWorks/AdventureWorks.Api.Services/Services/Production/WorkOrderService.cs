using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
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
    <Hash>f6e9a829f4dbd6c6c8e3f8ae1987c660</Hash>
</Codenesium>*/