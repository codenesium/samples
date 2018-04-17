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
			IJobCandidateModelValidator jobCandidateModelValidator)
			: base(logger, jobCandidateRepository, jobCandidateModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3c6deeeb88a98da8b91399338a774cea</Hash>
</Codenesium>*/