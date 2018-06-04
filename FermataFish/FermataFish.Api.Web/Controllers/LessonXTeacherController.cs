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
	[Route("api/lessonXTeachers")]
	[ApiVersion("1.0")]
	public class LessonXTeacherController: AbstractLessonXTeacherController
	{
		public LessonXTeacherController(
			ServiceSettings settings,
			ILogger<LessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXTeacherService lessonXTeacherService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonXTeacherService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5729eb5bb5eecd0b8aa51be8044de147</Hash>
</Codenesium>*/