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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/transactionStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class TransactionStatuController : AbstractTransactionStatuController
	{
		public TransactionStatuController(
			ApiSettings settings,
			ILogger<TransactionStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionStatuService transactionStatuService,
			IApiTransactionStatuServerModelMapper transactionStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionStatuService,
			       transactionStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bf7512c27a6faa40fe0d3f2bf110c9da</Hash>
</Codenesium>*/