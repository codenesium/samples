using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/jobCandidates")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(JobCandidateFilter))]
	public class JobCandidateController: AbstractJobCandidateController
	{
		public JobCandidateController(
			ILogger<JobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateRepository jobCandidateRepository
			)
			: base(logger,
			       transactionCoordinator,
			       jobCandidateRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>43f35bacaad13a26b44dc6ffedfa8f71</Hash>
</Codenesium>*/