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
	public class DepartmentController: AbstractDepartmentController
	{
		public DepartmentController(
			ILogger<DepartmentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDepartmentRepository departmentRepository,
			IDepartmentModelValidator departmentModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       departmentRepository,
			       departmentModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>96707bbf510cf53bda319785e6805ed1</Hash>
</Codenesium>*/