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
			ApplicationContext context,
			IWorkOrderRoutingRepository workOrderRoutingRepository,
			IWorkOrderRoutingModelValidator workOrderRoutingModelValidator
			) : base(logger,
			         context,
			         workOrderRoutingRepository,
			         workOrderRoutingModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f9e948dfc7e3fcfb49b8fd0397d4e173</Hash>
</Codenesium>*/