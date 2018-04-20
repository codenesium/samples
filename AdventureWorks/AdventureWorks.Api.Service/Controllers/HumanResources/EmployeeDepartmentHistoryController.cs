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
	[Route("api/employeeDepartmentHistories")]
	[ApiVersion("1.0")]
	[Response]
	public class EmployeeDepartmentHistoryController: AbstractEmployeeDepartmentHistoryController
	{
		public EmployeeDepartmentHistoryController(
			ServiceSettings settings,
			ILogger<EmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployeeDepartmentHistory employeeDepartmentHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeeDepartmentHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8642be7bce5b63f83f56c73b64a4772f</Hash>
</Codenesium>*/