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
	[Route("api/workOrderRoutings")]
	[ApiVersion("1.0")]
	public class WorkOrderRoutingController: AbstractWorkOrderRoutingController
	{
		public WorkOrderRoutingController(
			ServiceSettings settings,
			ILogger<WorkOrderRoutingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOWorkOrderRouting workOrderRoutingManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workOrderRoutingManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fbfdd38d112be437ab185b6e4d8b8e00</Hash>
</Codenesium>*/