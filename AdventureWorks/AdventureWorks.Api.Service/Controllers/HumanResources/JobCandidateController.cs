using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/jobCandidates")]
	[ApiVersion("1.0")]
	public class JobCandidateController: AbstractJobCandidateController
	{
		public JobCandidateController(
			ILogger<JobCandidateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOJobCandidate jobCandidateManager
			)
			: base(logger,
			       transactionCoordinator,
			       jobCandidateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>797b50b9ebf0d88370080ba6788d7503</Hash>
</Codenesium>*/