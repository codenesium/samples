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
			ApplicationContext context,
			IWorkOrderRepository workOrderRepository,
			IWorkOrderModelValidator workOrderModelValidator
			) : base(logger,
			         context,
			         workOrderRepository,
			         workOrderModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>693c77e0284f26eb70b3c68a0bdcba21</Hash>
</Codenesium>*/