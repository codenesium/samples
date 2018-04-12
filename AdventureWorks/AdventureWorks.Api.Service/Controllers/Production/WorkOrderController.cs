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
	[Route("api/workOrders")]
	public class WorkOrderController: AbstractWorkOrderController
	{
		public WorkOrderController(
			ILogger<WorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRepository workOrderRepository,
			IWorkOrderModelValidator workOrderModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       workOrderRepository,
			       workOrderModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6a6de38408e88cc80e32d9734de62cf8</Hash>
</Codenesium>*/