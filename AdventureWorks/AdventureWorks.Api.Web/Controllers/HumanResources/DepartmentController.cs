using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/departments")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DepartmentController : AbstractDepartmentController
	{
		public DepartmentController(
			ApiSettings settings,
			ILogger<DepartmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDepartmentService departmentService,
			IApiDepartmentModelMapper departmentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       departmentService,
			       departmentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>89885ac53826f18c49c2d3a85b6d75eb</Hash>
</Codenesium>*/