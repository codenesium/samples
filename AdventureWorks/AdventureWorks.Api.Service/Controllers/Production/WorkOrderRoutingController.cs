using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/workOrderRoutings")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(WorkOrderRoutingFilter))]
	public class WorkOrderRoutingController: AbstractWorkOrderRoutingController
	{
		public WorkOrderRoutingController(
			ILogger<WorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingRepository workOrderRoutingRepository
			)
			: base(logger,
			       transactionCoordinator,
			       workOrderRoutingRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e6562367f4b72cd776d264c0d91377a0</Hash>
</Codenesium>*/