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
                        ILogger<IWorkOrderRepository> logger,
                        IWorkOrderRepository workOrderRepository,
                        IApiWorkOrderRequestModelValidator workOrderModelValidator,
                        IBOLWorkOrderMapper bolworkOrderMapper,
                        IDALWorkOrderMapper dalworkOrderMapper
                        ,
                        IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper

                        )
                        : base(logger,
                               workOrderRepository,
                               workOrderModelValidator,
                               bolworkOrderMapper,
                               dalworkOrderMapper
                               ,
                               bolWorkOrderRoutingMapper,
                               dalWorkOrderRoutingMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>736d34743e0c7662c290723b9a8c7ded</Hash>
</Codenesium>*/