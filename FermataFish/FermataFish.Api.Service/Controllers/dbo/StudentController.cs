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
	[ServiceFilter(typeof(StudentFilter))]
	public class StudentController: AbstractStudentController
	{
		public StudentController(
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentRepository studentRepository
			)
			: base(logger,
			       transactionCoordinator,
			       studentRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8a6e18f281af275fdd20fc3f392c91f8</Hash>
</Codenesium>*/