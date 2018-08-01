using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class JobCandidateRepository : AbstractJobCandidateRepository, IJobCandidateRepository
	{
		public JobCandidateRepository(
			ILogger<JobCandidateRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c4920ccdd60e6a6758345ce1e2922ab2</Hash>
</Codenesium>*/