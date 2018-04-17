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
	[Route("api/lessonXStudents")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class LessonXStudentController: AbstractLessonXStudentController
	{
		public LessonXStudentController(
			ILogger<LessonXStudentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonXStudent lessonXStudentManager
			)
			: base(logger,
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
    <Hash>70c59601a4a969735fe9d87ac6e120fb</Hash>
</Codenesium>*/