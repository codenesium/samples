using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/customers")]
	public class CustomersController: AbstractCustomersController
	{
		public CustomersController(
			ILogger<CustomersController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerRepository customerRepository,
			ICustomerModelValidator customerModelValidator
			) : base(logger,
			         transactionCoordinator,
			         customerRepository,
			         customerModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3ca732f127c7274ca7c6849443b7320c</Hash>
</Codenesium>*/