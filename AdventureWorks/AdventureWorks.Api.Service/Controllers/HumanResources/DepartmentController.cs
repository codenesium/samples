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
	[Route("api/departments")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(DepartmentFilter))]
	public class DepartmentController: AbstractDepartmentController
	{
		public DepartmentController(
			ILogger<DepartmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDepartmentRepository departmentRepository
			)
			: base(logger,
			       transactionCoordinator,
			       departmentRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>490864de463139a28c23137b3db69ea8</Hash>
</Codenesium>*/