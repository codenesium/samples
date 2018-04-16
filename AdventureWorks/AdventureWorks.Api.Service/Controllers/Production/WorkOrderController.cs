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
	[Route("api/workOrders")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(WorkOrderFilter))]
	public class WorkOrderController: AbstractWorkOrderController
	{
		public WorkOrderController(
			ILogger<WorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRepository workOrderRepository
			)
			: base(logger,
			       transactionCoordinator,
			       workOrderRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>96a00e55493a64823b434f067a507c6c</Hash>
</Codenesium>*/