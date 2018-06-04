using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/customers")]
	[ApiVersion("1.0")]
	public class CustomerController: AbstractCustomerController
	{
		public CustomerController(
			ServiceSettings settings,
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerService customerService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       customerService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>add044f85be738f44f971f3860a0eaa5</Hash>
</Codenesium>*/