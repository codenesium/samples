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
			IBOLPipelineStepStatuMapper bolPipelineStepStatuMapper,
			IDALPipelineStepStatuMapper dalPipelineStepStatuMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base(logger,
			       mediator,
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
    <Hash>8f90f155b752c69cb04f63c10135f170</Hash>
</Codenesium>*/