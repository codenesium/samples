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
	[Route("api/lessonXTeachers")]
	[ApiVersion("1.0")]
	[Response]
	public class LessonXTeacherController: AbstractLessonXTeacherController
	{
		public LessonXTeacherController(
			ServiceSettings settings,
			ILogger<LessonXTeacherController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonXTeacher lessonXTeacherManager
			)
			: base(settings,
			       logger,
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
    <Hash>688cab8f06140af31c9c6fc1d5728fdf</Hash>
</Codenesium>*/