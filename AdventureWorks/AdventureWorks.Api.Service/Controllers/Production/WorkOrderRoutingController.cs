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
	public class WorkOrderRoutingsController: AbstractWorkOrderRoutingsController
	{
		public WorkOrderRoutingsController(
			ILogger<WorkOrderRoutingsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator
			) : base(logger,
			         transactionCoordinator,
			         workOrderRoutingRepository,
			         workOrderRoutingModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7ace8c16e64522030fbc16931f005f07</Hash>
</Codenesium>*/