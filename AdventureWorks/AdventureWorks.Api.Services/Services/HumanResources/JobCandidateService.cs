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
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base(logger,
			       mediator,
			       jobCandidateRepository,
			       jobCandidateModelValidator,
			       bolJobCandidateMapper,
			       dalJobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7e84136fcbd118ee3478fa92b024f4f2</Hash>
</Codenesium>*/