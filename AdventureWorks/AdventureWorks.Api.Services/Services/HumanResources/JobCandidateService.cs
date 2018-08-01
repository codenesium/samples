using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>7a2f6c8666bdb67bffab810f4489c655</Hash>
</Codenesium>*/