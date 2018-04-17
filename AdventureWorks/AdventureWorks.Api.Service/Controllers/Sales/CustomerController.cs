using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/customers")]
	[ApiVersion("1.0")]
	public class CustomerController: AbstractCustomerController
	{
		public CustomerController(
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCustomer customerManager
			)
			: base(logger,
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
    <Hash>ea2aca99d7906d38fac97d9af5e9a6e7</Hash>
</Codenesium>*/