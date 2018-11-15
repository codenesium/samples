using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/jobCandidates")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class JobCandidateController : AbstractJobCandidateController
	{
		public JobCandidateController(
			ApiSettings settings,
			ILogger<JobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateService jobCandidateService,
			IApiJobCandidateServerModelMapper jobCandidateModelMapper
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
    <Hash>b72a7b84066aae405c3e69f1ca16fa39</Hash>
</Codenesium>*/