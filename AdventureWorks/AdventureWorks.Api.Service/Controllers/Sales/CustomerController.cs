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
			ApplicationContext context,
			ICustomerRepository customerRepository,
			ICustomerModelValidator customerModelValidator
			) : base(logger,
			         context,
			         customerRepository,
			         customerModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c45778c931a802e1c34c472180c05053</Hash>
</Codenesium>*/