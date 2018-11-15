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
	[Route("api/customers")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CustomerController : AbstractCustomerController
	{
		public CustomerController(
			ApiSettings settings,
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerService customerService,
			IApiCustomerServerModelMapper customerModelMapper
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
    <Hash>95c22b428a5ed4f3c264d2043fa2c652</Hash>
</Codenesium>*/