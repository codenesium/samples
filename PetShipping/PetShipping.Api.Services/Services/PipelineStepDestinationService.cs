using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepDestinationService : AbstractPipelineStepDestinationService, IPipelineStepDestinationService
	{
		public PipelineStepDestinationService(
			ILogger<IPipelineStepDestinationRepository> logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationServerRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base(logger,
			       pipelineStepDestinationRepository,
			       pipelineStepDestinationModelValidator,
			       bolPipelineStepDestinationMapper,
			       dalPipelineStepDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a1347081fe9996b074ce6f6f65b9125a</Hash>
</Codenesium>*/