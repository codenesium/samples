using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
	[Route("api/students")]
	[ApiVersion("1.0")]
	public class StudentController: AbstractStudentController
	{
		public StudentController(
			ServiceSettings settings,
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentService studentService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       studentService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>564f66ffacf0dd963667681e255bd79d</Hash>
</Codenesium>*/