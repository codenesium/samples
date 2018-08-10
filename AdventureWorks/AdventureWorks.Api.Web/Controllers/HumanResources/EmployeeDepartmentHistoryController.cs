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
	[Route("api/employeeDepartmentHistories")]
	[ApiController]
	[ApiVersion("1.0")]
	public class EmployeeDepartmentHistoryController : AbstractEmployeeDepartmentHistoryController
	{
		public EmployeeDepartmentHistoryController(
			ApiSettings settings,
			ILogger<EmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryService employeeDepartmentHistoryService,
			IApiEmployeeDepartmentHistoryModelMapper employeeDepartmentHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeeDepartmentHistoryService,
			       employeeDepartmentHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>02bb43f15d99634eb489b5ecf4c9be00</Hash>
</Codenesium>*/