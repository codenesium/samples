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
        public class WorkOrderRoutingService : AbstractWorkOrderRoutingService, IWorkOrderRoutingService
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
                               dalworkOrderRoutingMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>55bcf778ef29761d82d19ecb078a02eb</Hash>
</Codenesium>*/