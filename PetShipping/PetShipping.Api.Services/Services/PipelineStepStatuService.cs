using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStatuService : AbstractPipelineStepStatuService, IPipelineStepStatuService
	{
		public PipelineStepStatuService(
			ILogger<IPipelineStepStatuRepository> logger,
			IMediator mediator,
			IPipelineStepStatuRepository pipelineStepStatuRepository,
			IApiPipelineStepStatuServerRequestModelValidator pipelineStepStatuModelValidator,
			IDALPipelineStepStatuMapper dalPipelineStepStatuMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base(logger,
			       mediator,
			       pipelineStepStatuRepository,
			       pipelineStepStatuModelValidator,
			       dalPipelineStepStatuMapper,
			       dalPipelineStepMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f1224da5308ac67180567f97202b9ead</Hash>
</Codenesium>*/