using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class JobCandidateService : AbstractJobCandidateService, IJobCandidateService
	{
		public JobCandidateService(
			ILogger<IJobCandidateRepository> logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper boljobCandidateMapper,
			IDALJobCandidateMapper daljobCandidateMapper
			)
			: base(logger,
			       jobCandidateRepository,
			       jobCandidateModelValidator,
			       boljobCandidateMapper,
			       daljobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6e2a492483899080354a1f0dec14c69a</Hash>
</Codenesium>*/