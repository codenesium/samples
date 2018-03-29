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
			ApplicationContext context,
			IJobCandidateRepository jobCandidateRepository,
			IJobCandidateModelValidator jobCandidateModelValidator
			) : base(logger,
			         context,
			         jobCandidateRepository,
			         jobCandidateModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1bb5b9d155a55a4d59094b2363573b08</Hash>
</Codenesium>*/