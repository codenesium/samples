using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/students")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class StudentController: AbstractStudentController
	{
		public StudentController(
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStudent studentManager
			)
			: base(logger,
			       transactionCoordinator,
			       studentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8ad6ea4b71e00e60366ee6f9eed12e78</Hash>
</Codenesium>*/