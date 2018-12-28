using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class HandlerService : AbstractHandlerService, IHandlerService
	{
		public HandlerService(
			ILogger<IHandlerRepository> logger,
			IMediator mediator,
			IHandlerRepository handlerRepository,
			IApiHandlerServerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper bolHandlerMapper,
			IDALHandlerMapper dalHandlerMapper,
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base(logger,
			       mediator,
			       handlerRepository,
			       handlerModelValidator,
			       bolHandlerMapper,
			       dalHandlerMapper,
			       bolAirTransportMapper,
			       dalAirTransportMapper,
			       bolHandlerPipelineStepMapper,
			       dalHandlerPipelineStepMapper,
			       bolOtherTransportMapper,
			       dalOtherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>0838868b4fe4f0f7daeba36e7bca10d1</Hash>
</Codenesium>*/