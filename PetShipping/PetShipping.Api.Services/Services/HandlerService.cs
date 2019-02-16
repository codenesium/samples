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
			IDALHandlerMapper dalHandlerMapper,
			IDALAirTransportMapper dalAirTransportMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base(logger,
			       mediator,
			       handlerRepository,
			       handlerModelValidator,
			       dalHandlerMapper,
			       dalAirTransportMapper,
			       dalHandlerPipelineStepMapper,
			       dalOtherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>962aaa332dbec20a3e0694fac782cd12</Hash>
</Codenesium>*/