using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class HandlerPipelineStepService : AbstractHandlerPipelineStepService, IHandlerPipelineStepService
	{
		public HandlerPipelineStepService(
			ILogger<IHandlerPipelineStepRepository> logger,
			IMediator mediator,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepServerRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
			: base(logger,
			       mediator,
			       handlerPipelineStepRepository,
			       handlerPipelineStepModelValidator,
			       bolHandlerPipelineStepMapper,
			       dalHandlerPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ca0368f14d408a4bbcd700f3c87fbe8</Hash>
</Codenesium>*/