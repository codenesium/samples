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
	[Route("api/lessonXStudents")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(LessonXStudentFilter))]
	public class LessonXStudentController: AbstractLessonXStudentController
	{
		public LessonXStudentController(
			ILogger<LessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXStudentRepository lessonXStudentRepository
			)
			: base(logger,
			       transactionCoordinator,
			       lessonXStudentRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>891a29f338324b3243f6677fc69509c0</Hash>
</Codenesium>*/