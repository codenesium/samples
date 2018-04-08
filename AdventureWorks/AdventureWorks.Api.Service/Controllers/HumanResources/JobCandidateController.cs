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
	public class JobCandidatesController: AbstractJobCandidatesController
	{
		public JobCandidatesController(
			ILogger<JobCandidatesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IJobCandidateRepository jobCandidateRepository,
			IJobCandidateModelValidator jobCandidateModelValidator
			) : base(logger,
			         transactionCoordinator,
			         jobCandidateRepository,
			         jobCandidateModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9e6420f631cf81484e0e3d4ea6cb54fa</Hash>
</Codenesium>*/