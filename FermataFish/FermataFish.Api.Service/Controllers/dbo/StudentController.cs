using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/students")]
	[ApiVersion("1.0")]
	public class StudentController: AbstractStudentController
	{
		public StudentController(
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentRepository studentRepository,
			IStudentModelValidator studentModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       studentRepository,
			       studentModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>285d6f9db649b6ac6bfab35dd03347ff</Hash>
</Codenesium>*/