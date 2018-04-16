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
	[ServiceFilter(typeof(LessonStatusFilter))]
	public class LessonStatusController: AbstractLessonStatusController
	{
		public LessonStatusController(
			ILogger<LessonStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonStatusRepository lessonStatusRepository
			)
			: base(logger,
			       transactionCoordinator,
			       lessonStatusRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4eef697b5548a677d5f8f6caae742a62</Hash>
</Codenesium>*/