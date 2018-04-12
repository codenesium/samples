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
	[Route("api/lessons")]
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
    <Hash>f9bef80eebe0c418ef048bf0b3b41602</Hash>
</Codenesium>*/