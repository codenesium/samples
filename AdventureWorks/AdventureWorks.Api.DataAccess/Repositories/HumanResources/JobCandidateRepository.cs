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
    <Hash>868330db512072dd68a4c5fe98c395cb</Hash>
</Codenesium>*/