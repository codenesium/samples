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
    <Hash>5a13ca82215968c1f1352fe4962ac659</Hash>
</Codenesium>*/