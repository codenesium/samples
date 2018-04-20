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
	[Route("api/departments")]
	[ApiVersion("1.0")]
	[Response]
	public class DepartmentController: AbstractDepartmentController
	{
		public DepartmentController(
			ServiceSettings settings,
			ILogger<DepartmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODepartment departmentManager
			)
			: base(settings,
			       logger,
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
    <Hash>7a5254e0424ce441dd4f4f056c3a8baa</Hash>
</Codenesium>*/