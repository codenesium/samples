using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Web
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
    <Hash>35104848326f1776c7c57c810cf77b4f</Hash>
</Codenesium>*/