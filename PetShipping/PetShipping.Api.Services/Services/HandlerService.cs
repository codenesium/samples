using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class HandlerService : AbstractHandlerService, IHandlerService
	{
		public HandlerService(
			ILogger<IHandlerRepository> logger,
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
    <Hash>aed15c6baf23ab2d4a7bae26c9644bd2</Hash>
</Codenesium>*/