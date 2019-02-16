using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepService : AbstractPipelineStepService, IPipelineStepService
	{
		public PipelineStepService(
			ILogger<IPipelineStepRepository> logger,
			IMediator mediator,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepServerRequestModelValidator pipelineStepModelValidator,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IDALOtherTransportMapper dalOtherTransportMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base(logger,
			       mediator,
			       pipelineStepRepository,
			       pipelineStepModelValidator,
			       dalPipelineStepMapper,
			       dalHandlerPipelineStepMapper,
			       dalOtherTransportMapper,
			       dalPipelineStepDestinationMapper,
			       dalPipelineStepNoteMapper,
			       dalPipelineStepStepRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b605add31387447cf30ea5f2dae4c7be</Hash>
</Codenesium>*/