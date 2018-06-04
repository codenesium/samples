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
			ILogger<WorkOrderRoutingRepository> logger,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IApiWorkOrderRoutingRequestModelValidator workOrderRoutingModelValidator,
			IBOLWorkOrderRoutingMapper BOLworkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper DALworkOrderRoutingMapper)
			: base(logger, workOrderRoutingRepository,
			       workOrderRoutingModelValidator,
			       BOLworkOrderRoutingMapper,
			       DALworkOrderRoutingMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5b8b5e4671e7d2712a85d11f784c46a7</Hash>
</Codenesium>*/