using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class JobCandidateRepository: AbstractJobCandidateRepository, IJobCandidateRepository
	{
		public JobCandidateRepository(
			ILogger<JobCandidateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>398d71a28644355628e02d33af87cdde</Hash>
</Codenesium>*/