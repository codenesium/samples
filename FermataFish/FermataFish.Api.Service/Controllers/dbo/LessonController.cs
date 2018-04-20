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
	[Route("api/lessons")]
	[ApiVersion("1.0")]
	[Response]
	public class LessonController: AbstractLessonController
	{
		public LessonController(
			ServiceSettings settings,
			ILogger<LessonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLesson lessonManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ce1f71820906d3b68ee9b129277d27ba</Hash>
</Codenesium>*/