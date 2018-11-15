using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineService : AbstractPipelineService, IPipelineService
	{
		public PipelineService(
			ILogger<IPipelineRepository> logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineServerRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
			       pipelineRepository,
			       pipelineModelValidator,
			       bolPipelineMapper,
			       dalPipelineMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>27701a6b081191befb210b5deb04d15a</Hash>
</Codenesium>*/