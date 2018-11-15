using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/students")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class StudentController : AbstractStudentController
	{
		public StudentController(
			ApiSettings settings,
			ILogger<StudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudentService studentService,
			IApiStudentServerModelMapper studentModelMapper
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
    <Hash>bffbb281343cf8aea8277c5e9d8622ec</Hash>
</Codenesium>*/