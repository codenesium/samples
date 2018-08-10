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
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
{
	[Route("api/lessonXStudents")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LessonXStudentController : AbstractLessonXStudentController
	{
		public LessonXStudentController(
			ApiSettings settings,
			ILogger<LessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXStudentService lessonXStudentService,
			IApiLessonXStudentModelMapper lessonXStudentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonXStudentService,
			       lessonXStudentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>45c25dc5d68ad2ef73b7fed8b26ccc9b</Hash>
</Codenesium>*/