using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class HandlerPipelineStepService : AbstractHandlerPipelineStepService, IHandlerPipelineStepService
	{
		public HandlerPipelineStepService(
			ILogger<IHandlerPipelineStepRepository> logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepServerRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
			: base(logger,
			       handlerPipelineStepRepository,
			       handlerPipelineStepModelValidator,
			       bolHandlerPipelineStepMapper,
			       dalHandlerPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>dd02a6c1c1f30ff1176624aabc931d15</Hash>
</Codenesium>*/