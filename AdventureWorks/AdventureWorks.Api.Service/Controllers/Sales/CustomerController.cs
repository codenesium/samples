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
	public class CustomerController: AbstractCustomerController
	{
		public CustomerController(
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerRepository customerRepository,
			ICustomerModelValidator customerModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       customerRepository,
			       customerModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0f3a3fa9b313ae44c346cd6edfec2d08</Hash>
</Codenesium>*/