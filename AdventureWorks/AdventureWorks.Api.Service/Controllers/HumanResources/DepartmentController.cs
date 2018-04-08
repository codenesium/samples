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
	[Route("api/departments")]
	public class DepartmentsController: AbstractDepartmentsController
	{
		public DepartmentsController(
			ILogger<DepartmentsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDepartmentRepository departmentRepository,
			IDepartmentModelValidator departmentModelValidator
			) : base(logger,
			         transactionCoordinator,
			         departmentRepository,
			         departmentModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5f854cf98a18d3e56668634576a40d77</Hash>
</Codenesium>*/