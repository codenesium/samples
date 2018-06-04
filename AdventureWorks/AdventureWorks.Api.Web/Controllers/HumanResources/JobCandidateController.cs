using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/jobCandidates")]
	[ApiVersion("1.0")]
	public class JobCandidateController: AbstractJobCandidateController
	{
		public JobCandidateController(
			ServiceSettings settings,
			ILogger<JobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateService jobCandidateService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       jobCandidateService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>16956e8b47a2bbf285c1c90a89eddf31</Hash>
</Codenesium>*/