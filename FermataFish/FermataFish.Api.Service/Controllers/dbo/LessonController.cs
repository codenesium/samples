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
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d725c34db89a3d3b2c6862234ba373a7</Hash>
</Codenesium>*/