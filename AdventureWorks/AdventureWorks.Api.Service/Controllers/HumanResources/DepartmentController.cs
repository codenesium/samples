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
			ApplicationContext context,
			IDepartmentRepository departmentRepository,
			IDepartmentModelValidator departmentModelValidator
			) : base(logger,
			         context,
			         departmentRepository,
			         departmentModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a45cd8de3ffe221fc3f2ece6de31c462</Hash>
</Codenesium>*/