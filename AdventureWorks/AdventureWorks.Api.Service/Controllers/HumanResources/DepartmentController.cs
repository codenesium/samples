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
    <Hash>c5fa44e8bc3d8bca4636537ec7910847</Hash>
</Codenesium>*/