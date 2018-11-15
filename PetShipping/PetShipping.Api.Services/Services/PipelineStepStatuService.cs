using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStatuService : AbstractPipelineStepStatuService, IPipelineStepStatuService
	{
		public PipelineStepStatuService(
			ILogger<IPipelineStepStatuRepository> logger,
			IPipelineStepStatuRepository pipelineStepStatuRepository,
			IApiPipelineStepStatuServerRequestModelValidator pipelineStepStatuModelValidator,
			IBOLPipelineStepStatuMapper bolPipelineStepStatuMapper,
			IDALPipelineStepStatuMapper dalPipelineStepStatuMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base(logger,
			       pipelineStepStatuRepository,
			       pipelineStepStatuModelValidator,
			       bolPipelineStepStatuMapper,
			       dalPipelineStepStatuMapper,
			       bolPipelineStepMapper,
			       dalPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ebf133fc21d0d804a2146b0dbbb4ce5f</Hash>
</Codenesium>*/