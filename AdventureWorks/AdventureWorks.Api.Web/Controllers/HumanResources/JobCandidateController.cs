using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/jobCandidates")]
	[ApiController]
	[ApiVersion("1.0")]
	public class JobCandidateController : AbstractJobCandidateController
	{
		public JobCandidateController(
			ApiSettings settings,
			ILogger<JobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateService jobCandidateService,
			IApiJobCandidateModelMapper jobCandidateModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       jobCandidateService,
			       jobCandidateModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>054295385513fd9afb0ca97b3b6c17af</Hash>
</Codenesium>*/