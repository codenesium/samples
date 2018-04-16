using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/lessonXTeachers")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(LessonXTeacherFilter))]
	public class LessonXTeacherController: AbstractLessonXTeacherController
	{
		public LessonXTeacherController(
			ILogger<LessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXTeacherRepository lessonXTeacherRepository
			)
			: base(logger,
			       transactionCoordinator,
			       lessonXTeacherRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d08cb7aa612d0d024cc7af8e5e016b63</Hash>
</Codenesium>*/