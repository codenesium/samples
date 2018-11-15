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
	[Route("api/teachers")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class TeacherController : AbstractTeacherController
	{
		public TeacherController(
			ApiSettings settings,
			ILogger<TeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeacherService teacherService,
			IApiTeacherServerModelMapper teacherModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teacherService,
			       teacherModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c4f7acd56faebc38d0af6bf54b584d5f</Hash>
</Codenesium>*/