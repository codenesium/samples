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
	[Route("api/lessons")]
	[ApiVersion("1.0")]
	public class LessonController: AbstractLessonController
	{
		public LessonController(
			ILogger<LessonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonRepository lessonRepository,
			ILessonModelValidator lessonModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       lessonRepository,
			       lessonModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>628e58f2c98d8ed8bac8b4de1c428509</Hash>
</Codenesium>*/