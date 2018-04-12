using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/jobCandidates")]
	public class JobCandidateController: AbstractJobCandidateController
	{
		public JobCandidateController(
			ILogger<JobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateRepository jobCandidateRepository,
			IJobCandidateModelValidator jobCandidateModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       jobCandidateRepository,
			       jobCandidateModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4ea45807e8b6840c3fbb4b37c2413b2a</Hash>
</Codenesium>*/