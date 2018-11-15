using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStatuService : AbstractPipelineStatuService, IPipelineStatuService
	{
		public PipelineStatuService(
			ILogger<IPipelineStatuRepository> logger,
			IPipelineStatuRepository pipelineStatuRepository,
			IApiPipelineStatuServerRequestModelValidator pipelineStatuModelValidator,
			IBOLPipelineStatuMapper bolPipelineStatuMapper,
			IDALPipelineStatuMapper dalPipelineStatuMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base(logger,
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
    <Hash>fd385b0bf673ede867129d53c1d637b8</Hash>
</Codenesium>*/