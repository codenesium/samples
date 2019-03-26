using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
			IApiDepartmentServerModelMapper departmentModelMapper
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
    <Hash>388d1a2673a23b2c80ae76ec2a1c94c4</Hash>
</Codenesium>*/