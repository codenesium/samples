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
	[ServiceFilter(typeof(LessonFilter))]
	public class LessonController: AbstractLessonController
	{
		public LessonController(
			ILogger<LessonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonRepository lessonRepository
			)
			: base(logger,
			       transactionCoordinator,
			       lessonRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2e13f5db995a57c4258d10c5c9a52350</Hash>
</Codenesium>*/