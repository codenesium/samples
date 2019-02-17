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

	public class TransactionStatusController : AbstractTransactionStatusController
	{
		public TransactionStatusController(
			ApiSettings settings,
			ILogger<TransactionStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITransactionStatusService transactionStatusService,
			IApiTransactionStatusServerModelMapper transactionStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       transactionStatusService,
			       transactionStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>97a84bd23cd4d6993a3471c10a0c9092</Hash>
</Codenesium>*/