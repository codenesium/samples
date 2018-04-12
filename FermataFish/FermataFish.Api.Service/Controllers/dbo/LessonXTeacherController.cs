using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/lessonXTeachers")]
	public class LessonXTeacherController: AbstractLessonXTeacherController
	{
		public LessonXTeacherController(
			ILogger<LessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXTeacherRepository lessonXTeacherRepository,
			ILessonXTeacherModelValidator lessonXTeacherModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       lessonXTeacherRepository,
			       lessonXTeacherModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a41406889a092617de2a67fc34116877</Hash>
</Codenesium>*/