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
	[Route("api/departments")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class DepartmentController: AbstractDepartmentController
	{
		public DepartmentController(
			ILogger<DepartmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODepartment departmentManager
			)
			: base(logger,
			       transactionCoordinator,
			       departmentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>965c6cac7ffe2c924b6e27d149fa9900</Hash>
</Codenesium>*/