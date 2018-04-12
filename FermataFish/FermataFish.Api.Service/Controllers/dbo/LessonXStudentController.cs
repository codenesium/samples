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
	[Route("api/lessonXStudents")]
	public class LessonXStudentController: AbstractLessonXStudentController
	{
		public LessonXStudentController(
			ILogger<LessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonXStudentRepository lessonXStudentRepository,
			ILessonXStudentModelValidator lessonXStudentModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       lessonXStudentRepository,
			       lessonXStudentModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>25ec337eb2fdeb02864f943b3cce37e1</Hash>
</Codenesium>*/