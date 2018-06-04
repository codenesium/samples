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
	[Route("api/lessonXStudents")]
	[ApiVersion("1.0")]
	public class LessonXStudentController: AbstractLessonXStudentController
	{
		public LessonXStudentController(
			ServiceSettings settings,
			ILogger<LessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXStudentService lessonXStudentService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonXStudentService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3f8d3cb8ae252e03c42e7af08513f3d5</Hash>
</Codenesium>*/