using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStatuService : AbstractPipelineStatuService, IPipelineStatuService
	{
		public PipelineStatuService(
			ILogger<IPipelineStatuRepository> logger,
			IMediator mediator,
			IPipelineStatuRepository pipelineStatuRepository,
			IApiPipelineStatuServerRequestModelValidator pipelineStatuModelValidator,
			IBOLPipelineStatuMapper bolPipelineStatuMapper,
			IDALPipelineStatuMapper dalPipelineStatuMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       mediator,
			       pipelineStatuRepository,
			       pipelineStatuModelValidator,
			       bolPipelineStatuMapper,
			       dalPipelineStatuMapper,
			       bolPipelineMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c8fddd3bc54c191445c32c35422d8b62</Hash>
</Codenesium>*/