using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DestinationService : AbstractDestinationService, IDestinationService
	{
		public DestinationService(
			ILogger<IDestinationRepository> logger,
			IMediator mediator,
			IDestinationRepository destinationRepository,
			IApiDestinationServerRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base(logger,
			       mediator,
			       destinationRepository,
			       destinationModelValidator,
			       bolDestinationMapper,
			       dalDestinationMapper,
			       bolPipelineStepDestinationMapper,
			       dalPipelineStepDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>96ad9f83d3e8a78ced794632e37a07d8</Hash>
</Codenesium>*/