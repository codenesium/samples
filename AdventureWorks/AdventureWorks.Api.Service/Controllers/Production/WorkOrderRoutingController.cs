using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/workOrderRoutings")]
	public class WorkOrderRoutingController: AbstractWorkOrderRoutingController
	{
		public WorkOrderRoutingController(
			ILogger<WorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       workOrderRoutingRepository,
			       workOrderRoutingModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f899d6339ed6cbde615028be3ef6d289</Hash>
</Codenesium>*/