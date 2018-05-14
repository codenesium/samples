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
			IApiJobCandidateModelValidator jobCandidateModelValidator)
			: base(logger, jobCandidateRepository, jobCandidateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>5251644855d36fdd92fe7fd3b3d6d7a1</Hash>
</Codenesium>*/