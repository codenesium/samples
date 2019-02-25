using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStatusService : AbstractPipelineStepStatusService, IPipelineStepStatusService
	{
		public PipelineStepStatusService(
			ILogger<IPipelineStepStatusRepository> logger,
			IMediator mediator,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusServerRequestModelValidator pipelineStepStatusModelValidator,
			IDALPipelineStepStatusMapper dalPipelineStepStatusMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base(logger,
			       mediator,
			       pipelineStepStatusRepository,
			       pipelineStepStatusModelValidator,
			       dalPipelineStepStatusMapper,
			       dalPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>102714beaecd49ee5270e20467686a0b</Hash>
</Codenesium>*/