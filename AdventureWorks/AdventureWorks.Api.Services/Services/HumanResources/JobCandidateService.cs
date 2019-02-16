using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class JobCandidateService : AbstractJobCandidateService, IJobCandidateService
	{
		public JobCandidateService(
			ILogger<IJobCandidateRepository> logger,
			IMediator mediator,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateServerRequestModelValidator jobCandidateModelValidator,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base(logger,
			       mediator,
			       jobCandidateRepository,
			       jobCandidateModelValidator,
			       dalJobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b581489e61a641622e2b27712433893f</Hash>
</Codenesium>*/