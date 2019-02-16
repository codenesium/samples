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
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
			: base(logger,
			       mediator,
			       handlerPipelineStepRepository,
			       handlerPipelineStepModelValidator,
			       dalHandlerPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b6398f8081562d898e320d6d62379a4d</Hash>
</Codenesium>*/