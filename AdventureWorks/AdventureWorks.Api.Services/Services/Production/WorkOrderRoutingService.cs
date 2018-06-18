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
        public class WorkOrderRoutingService: AbstractWorkOrderRoutingService, IWorkOrderRoutingService
        {
                public WorkOrderRoutingService(
                        ILogger<IWorkOrderRoutingRepository> logger,
                        IWorkOrderRoutingRepository workOrderRoutingRepository,
                        IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
                        IBOLWorkOrderRoutingMapper bolworkOrderRoutingMapper,
                        IDALWorkOrderRoutingMapper dalworkOrderRoutingMapper

                        )
                        : base(logger,
                               workOrderRoutingRepository,
                               workOrderRoutingModelValidator,
                               bolworkOrderRoutingMapper,
                               dalworkOrderRoutingMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>bcfc2cd7c6d75fb24f03864d2c8e0116</Hash>
</Codenesium>*/