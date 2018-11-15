using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class JobCandidateService : AbstractJobCandidateService, IJobCandidateService
	{
		public JobCandidateService(
			ILogger<IJobCandidateRepository> logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateServerRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base(logger,
			       jobCandidateRepository,
			       jobCandidateModelValidator,
			       bolJobCandidateMapper,
			       dalJobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d5e08083458a852471079cbec4e1a555</Hash>
</Codenesium>*/