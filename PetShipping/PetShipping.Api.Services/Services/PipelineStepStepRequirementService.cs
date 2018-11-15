using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepStepRequirementService : AbstractPipelineStepStepRequirementService, IPipelineStepStepRequirementService
	{
		public PipelineStepStepRequirementService(
			ILogger<IPipelineStepStepRequirementRepository> logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementServerRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base(logger,
			       pipelineStepStepRequirementRepository,
			       pipelineStepStepRequirementModelValidator,
			       bolPipelineStepStepRequirementMapper,
			       dalPipelineStepStepRequirementMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>595304650359c8f31073077e9635c827</Hash>
</Codenesium>*/