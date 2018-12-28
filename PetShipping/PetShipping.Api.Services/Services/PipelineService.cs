using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineService : AbstractPipelineService, IPipelineService
	{
		public PipelineService(
			ILogger<IPipelineRepository> logger,
			IMediator mediator,
			IPipelineRepository pipelineRepository,
			IApiPipelineServerRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       mediator,
			       pipelineRepository,
			       pipelineModelValidator,
			       bolPipelineMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3ba392d6a72885def7b654f1b443f78e</Hash>
</Codenesium>*/