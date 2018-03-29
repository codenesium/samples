using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/employeeDepartmentHistories")]
	public class EmployeeDepartmentHistoriesController: AbstractEmployeeDepartmentHistoriesController
	{
		public EmployeeDepartmentHistoriesController(
			ILogger<EmployeeDepartmentHistoriesController> logger,
			ApplicationContext context,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator
			) : base(logger,
			         context,
			         employeeDepartmentHistoryRepository,
			         employeeDepartmentHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7a0d02af58e82efb6399f573488ca9dd</Hash>
</Codenesium>*/