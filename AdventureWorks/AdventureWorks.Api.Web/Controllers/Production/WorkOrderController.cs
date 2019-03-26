using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/workOrders")]
	[ApiController]
	[ApiVersion("1.0")]

	public class WorkOrderController : AbstractWorkOrderController
	{
		public WorkOrderController(
			ApiSettings settings,
			ILogger<WorkOrderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IWorkOrderService workOrderService,
			IApiWorkOrderServerModelMapper workOrderModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       workOrderService,
			       workOrderModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0f126bfdf70cad1afec658d29308438c</Hash>
</Codenesium>*/