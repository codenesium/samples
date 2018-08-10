using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>2c7a6cfd75a1de9330c31968515960ed</Hash>
</Codenesium>*/