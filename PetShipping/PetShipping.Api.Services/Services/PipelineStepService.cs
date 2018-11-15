using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepService : AbstractPipelineStepService, IPipelineStepService
	{
		public PipelineStepService(
			ILogger<IPipelineStepRepository> logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepServerRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base(logger,
			       pipelineStepRepository,
			       pipelineStepModelValidator,
			       bolPipelineStepMapper,
			       dalPipelineStepMapper,
			       bolHandlerPipelineStepMapper,
			       dalHandlerPipelineStepMapper,
			       bolOtherTransportMapper,
			       dalOtherTransportMapper,
			       bolPipelineStepDestinationMapper,
			       dalPipelineStepDestinationMapper,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper,
			       bolPipelineStepStepRequirementMapper,
			       dalPipelineStepStepRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fae452b747b3505745e0378ce4777475</Hash>
</Codenesium>*/