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
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       mediator,
			       pipelineRepository,
			       pipelineModelValidator,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>67ef19ce34d586d75e9413d08a19758a</Hash>
</Codenesium>*/