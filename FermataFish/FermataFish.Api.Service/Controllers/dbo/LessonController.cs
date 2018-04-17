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
	[Route("api/lessons")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class LessonController: AbstractLessonController
	{
		public LessonController(
			ILogger<LessonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOLesson lessonManager
			)
			: base(logger,
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
    <Hash>2b34782b43120e3226a157953ca44c03</Hash>
</Codenesium>*/