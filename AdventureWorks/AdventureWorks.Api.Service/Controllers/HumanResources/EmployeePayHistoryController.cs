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
	[Route("api/employeePayHistories")]
	public class EmployeePayHistoriesController: AbstractEmployeePayHistoriesController
	{
		public EmployeePayHistoriesController(
			ILogger<EmployeePayHistoriesController> logger,
			ApplicationContext context,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IEmployeePayHistoryModelValidator employeePayHistoryModelValidator
			) : base(logger,
			         context,
			         employeePayHistoryRepository,
			         employeePayHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6a376f2e952149b550230d5ffa457229</Hash>
</Codenesium>*/