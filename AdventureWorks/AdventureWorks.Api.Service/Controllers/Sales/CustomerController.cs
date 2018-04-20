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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/customers")]
	[ApiVersion("1.0")]
	[Response]
	public class CustomerController: AbstractCustomerController
	{
		public CustomerController(
			ServiceSettings settings,
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCustomer customerManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       customerManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>975105fa2314b378ecb5a527fe687287</Hash>
</Codenesium>*/