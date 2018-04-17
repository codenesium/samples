using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/workOrders")]
	[ApiVersion("1.0")]
	public class WorkOrderController: AbstractWorkOrderController
	{
		public WorkOrderController(
			ILogger<WorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOWorkOrder workOrderManager
			)
			: base(logger,
			       transactionCoordinator,
			       workOrderManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d6838fba884b4935381d76b61f359e38</Hash>
</Codenesium>*/