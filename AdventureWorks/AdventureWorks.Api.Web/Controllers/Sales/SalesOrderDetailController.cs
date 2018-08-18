using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/salesOrderDetails")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SalesOrderDetailController : AbstractSalesOrderDetailController
	{
		public SalesOrderDetailController(
			ApiSettings settings,
			ILogger<SalesOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderDetailService salesOrderDetailService,
			IApiSalesOrderDetailModelMapper salesOrderDetailModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesOrderDetailService,
			       salesOrderDetailModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c0212793e13828273b3aa728ebc4ae1f</Hash>
</Codenesium>*/