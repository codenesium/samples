using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/customers")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(CustomerFilter))]
	public class CustomerController: AbstractCustomerController
	{
		public CustomerController(
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerRepository customerRepository
			)
			: base(logger,
			       transactionCoordinator,
			       customerRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>eeec28e4e0ac35e477af8df93c8b0960</Hash>
</Codenesium>*/