using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/workOrders")]
	[ApiVersion("1.0")]
	public class WorkOrderController: AbstractWorkOrderController
	{
		public WorkOrderController(
			ServiceSettings settings,
			ILogger<WorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOWorkOrder workOrderManager
			)
			: base(settings,
			       logger,
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
    <Hash>f8057f211c70cb049f43467695302cd9</Hash>
</Codenesium>*/