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
	public class WorkOrdersController: AbstractWorkOrdersController
	{
		public WorkOrdersController(
			ILogger<WorkOrdersController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRepository workOrderRepository,
			IWorkOrderModelValidator workOrderModelValidator
			) : base(logger,
			         transactionCoordinator,
			         workOrderRepository,
			         workOrderModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bb504029ce860596c2428108f6e56b93</Hash>
</Codenesium>*/