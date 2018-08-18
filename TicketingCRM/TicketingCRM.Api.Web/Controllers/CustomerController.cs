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
	[Route("api/customers")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CustomerController : AbstractCustomerController
	{
		public CustomerController(
			ApiSettings settings,
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerService customerService,
			IApiCustomerModelMapper customerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       customerService,
			       customerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a417085ee5975825ea430d5e36bfdb16</Hash>
</Codenesium>*/