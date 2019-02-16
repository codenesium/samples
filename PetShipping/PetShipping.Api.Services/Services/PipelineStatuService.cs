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
			IDALPipelineStatuMapper dalPipelineStatuMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       mediator,
			       pipelineStatuRepository,
			       pipelineStatuModelValidator,
			       dalPipelineStatuMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f87b61d389209dc1029d15b2f53c62aa</Hash>
</Codenesium>*/