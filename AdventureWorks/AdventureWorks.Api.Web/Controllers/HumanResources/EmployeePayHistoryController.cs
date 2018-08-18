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
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/employeePayHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class EmployeePayHistoryController : AbstractEmployeePayHistoryController
	{
		public EmployeePayHistoryController(
			ApiSettings settings,
			ILogger<EmployeePayHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeePayHistoryService employeePayHistoryService,
			IApiEmployeePayHistoryModelMapper employeePayHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeePayHistoryService,
			       employeePayHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>49fb86caa059c9932bfc38ae617e8291</Hash>
</Codenesium>*/