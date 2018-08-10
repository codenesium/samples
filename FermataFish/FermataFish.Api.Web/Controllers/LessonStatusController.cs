using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Web
{
	[Route("api/lessonStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LessonStatusController : AbstractLessonStatusController
	{
		public LessonStatusController(
			ApiSettings settings,
			ILogger<LessonStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILessonStatusService lessonStatusService,
			IApiLessonStatusModelMapper lessonStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       lessonStatusService,
			       lessonStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>65d7dea6e21ee5ddf848027f4bd25d84</Hash>
</Codenesium>*/