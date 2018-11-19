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
    <Hash>4d162c850957ea9dccc6fabbb87d107b</Hash>
</Codenesium>*/