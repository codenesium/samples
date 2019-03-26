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
	[Route("api/salesOrderHeaders")]
	[ApiController]
	[ApiVersion("1.0")]

	public class SalesOrderHeaderController : AbstractSalesOrderHeaderController
	{
		public SalesOrderHeaderController(
			ApiSettings settings,
			ILogger<SalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderService salesOrderHeaderService,
			IApiSalesOrderHeaderServerModelMapper salesOrderHeaderModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesOrderHeaderService,
			       salesOrderHeaderModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>04df29e4f5da8a4902785e3252e71bf0</Hash>
</Codenesium>*/