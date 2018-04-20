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
	[Route("api/lessonStatus")]
	[ApiVersion("1.0")]
	[Response]
	public class LessonStatusController: AbstractLessonStatusController
	{
		public LessonStatusController(
			ServiceSettings settings,
			ILogger<LessonStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLessonStatus lessonStatusManager
			)
			: base(settings,
			       logger,
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
    <Hash>418821af2c7a9a7473c3e7c98eaee061</Hash>
</Codenesium>*/