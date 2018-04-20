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
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/lessonXStudents")]
	[ApiVersion("1.0")]
	[Response]
	public class LessonXStudentController: AbstractLessonXStudentController
	{
		public LessonXStudentController(
			ServiceSettings settings,
			ILogger<LessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonXStudent lessonXStudentManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonXStudentManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b467d4f78f6d009976b30551685a1de9</Hash>
</Codenesium>*/