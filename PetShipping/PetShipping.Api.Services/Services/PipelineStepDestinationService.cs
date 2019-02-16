using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepDestinationService : AbstractPipelineStepDestinationService, IPipelineStepDestinationService
	{
		public PipelineStepDestinationService(
			ILogger<IPipelineStepDestinationRepository> logger,
			IMediator mediator,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationServerRequestModelValidator pipelineStepDestinationModelValidator,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base(logger,
			       mediator,
			       pipelineStepDestinationRepository,
			       pipelineStepDestinationModelValidator,
			       dalPipelineStepDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5d2d400a558a49109518a2e35be4b2e1</Hash>
</Codenesium>*/