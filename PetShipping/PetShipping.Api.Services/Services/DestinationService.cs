using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DestinationService : AbstractDestinationService, IDestinationService
	{
		public DestinationService(
			ILogger<IDestinationRepository> logger,
			IDestinationRepository destinationRepository,
			IApiDestinationServerRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base(logger,
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
    <Hash>b156acb0b31f410188636d06781e57a2</Hash>
</Codenesium>*/