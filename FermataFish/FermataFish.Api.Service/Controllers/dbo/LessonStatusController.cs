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
	[Route("api/lessonStatus")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class LessonStatusController: AbstractLessonStatusController
	{
		public LessonStatusController(
			ILogger<LessonStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonStatus lessonStatusManager
			)
			: base(logger,
			       transactionCoordinator,
			       lessonStatusManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c3264a7aafc3c0f4338d993252c1cc8b</Hash>
</Codenesium>*/