using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/workOrderRoutings")]
	[ApiController]
	[ApiVersion("1.0")]
	public class WorkOrderRoutingController : AbstractWorkOrderRoutingController
	{
		public WorkOrderRoutingController(
			ApiSettings settings,
			ILogger<WorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingService workOrderRoutingService,
			IApiWorkOrderRoutingModelMapper workOrderRoutingModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workOrderRoutingService,
			       workOrderRoutingModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>43cc75ea8174896b990b9192b965a472</Hash>
</Codenesium>*/