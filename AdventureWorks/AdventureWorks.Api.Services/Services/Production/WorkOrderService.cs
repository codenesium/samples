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
        public partial class WorkOrderService : AbstractWorkOrderService, IWorkOrderService
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
    <Hash>6957e6cd840be7ef93473e1de80f3d5e</Hash>
</Codenesium>*/