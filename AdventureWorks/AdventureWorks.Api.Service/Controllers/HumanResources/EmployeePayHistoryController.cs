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
	[Route("api/employeePayHistories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(EmployeePayHistoryFilter))]
	public class EmployeePayHistoryController: AbstractEmployeePayHistoryController
	{
		public EmployeePayHistoryController(
			ILogger<EmployeePayHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeePayHistoryRepository employeePayHistoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       employeePayHistoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cbbeb5de9aaf15c26429923d24b5a57e</Hash>
</Codenesium>*/