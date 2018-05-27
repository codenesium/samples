using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class JobCandidateRepository: AbstractJobCandidateRepository, IJobCandidateRepository
	{
		public JobCandidateRepository(
			IDALJobCandidateMapper mapper,
			ILogger<JobCandidateRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>cf8fc3ed02fcebff277648b937514a3a</Hash>
</Codenesium>*/