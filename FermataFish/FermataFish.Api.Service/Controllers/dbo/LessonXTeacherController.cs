using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/lessonXTeachers")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class LessonXTeacherController: AbstractLessonXTeacherController
	{
		public LessonXTeacherController(
			ILogger<LessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonXTeacher lessonXTeacherManager
			)
			: base(logger,
			       transactionCoordinator,
			       lessonXTeacherManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c593a35eaea18f6a4f50961bf4a20ea4</Hash>
</Codenesium>*/