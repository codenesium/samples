using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
	[Route("api/students")]
	[ApiController]
	[ApiVersion("1.0")]
	public class StudentController : AbstractStudentController
	{
		public StudentController(
			ApiSettings settings,
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentService studentService,
			IApiStudentModelMapper studentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       studentService,
			       studentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>72912a14275d07f48b31ffcc279de16f</Hash>
</Codenesium>*/