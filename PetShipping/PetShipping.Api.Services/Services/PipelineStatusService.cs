using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStatusService : AbstractPipelineStatusService, IPipelineStatusService
	{
		public PipelineStatusService(
			ILogger<IPipelineStatusRepository> logger,
			IMediator mediator,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusServerRequestModelValidator pipelineStatusModelValidator,
			IDALPipelineStatusMapper dalPipelineStatusMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       mediator,
			       pipelineStatusRepository,
			       pipelineStatusModelValidator,
			       dalPipelineStatusMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b8c50d9f3ee9076fcaa1d7f852acb6a0</Hash>
</Codenesium>*/