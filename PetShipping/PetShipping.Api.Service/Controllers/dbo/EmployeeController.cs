using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/employees")]
	[ApiVersion("1.0")]
	[Response]
	public class EmployeeController: AbstractEmployeeController
	{
		public EmployeeController(
			ServiceSettings settings,
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployee employeeManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>26fee43bc476c67bd184bba8204da4b2</Hash>
</Codenesium>*/