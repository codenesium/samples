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
	[Route("api/lessonStatus")]
	[ApiVersion("1.0")]
	public class LessonStatusController: AbstractLessonStatusController
	{
		public LessonStatusController(
			ILogger<LessonStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonStatusRepository lessonStatusRepository,
			ILessonStatusModelValidator lessonStatusModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       lessonStatusRepository,
			       lessonStatusModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e402de969a523ef57a646db1a83c308a</Hash>
</Codenesium>*/