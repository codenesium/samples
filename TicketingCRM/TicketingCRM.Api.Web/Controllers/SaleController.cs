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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/sales")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SaleController : AbstractSaleController
	{
		public SaleController(
			ApiSettings settings,
			ILogger<SaleController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISaleService saleService,
			IApiSaleModelMapper saleModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       saleService,
			       saleModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dd3900c02aff37c2582286a77b48bd0f</Hash>
</Codenesium>*/