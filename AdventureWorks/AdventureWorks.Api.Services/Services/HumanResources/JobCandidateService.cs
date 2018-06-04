using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class JobCandidateService: AbstractJobCandidateService, IJobCandidateService
	{
		public JobCandidateService(
			ILogger<JobCandidateRepository> logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper BOLjobCandidateMapper,
			IDALJobCandidateMapper DALjobCandidateMapper)
			: base(logger, jobCandidateRepository,
			       jobCandidateModelValidator,
			       BOLjobCandidateMapper,
			       DALjobCandidateMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>65181ac1984dff25836515e9d90e8da8</Hash>
</Codenesium>*/