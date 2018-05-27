using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOJobCandidate: AbstractBOJobCandidate, IBOJobCandidate
	{
		public BOJobCandidate(
			ILogger<JobCandidateRepository> logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper jobCandidateMapper)
			: base(logger, jobCandidateRepository, jobCandidateModelValidator, jobCandidateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f0f75447e93cec6e2d3673722a8ade3e</Hash>
</Codenesium>*/