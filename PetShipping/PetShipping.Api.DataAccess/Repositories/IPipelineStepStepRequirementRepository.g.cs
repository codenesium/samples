using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepStepRequirementRepository
	{
		Task<PipelineStepStepRequirement> Create(PipelineStepStepRequirement item);

		Task Update(PipelineStepStepRequirement item);

		Task Delete(int id);

		Task<PipelineStepStepRequirement> Get(int id);

		Task<List<PipelineStepStepRequirement>> All(int limit = int.MaxValue, int offset = 0);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>e35d64f163c72eb08c9e5d37b88b7c04</Hash>
</Codenesium>*/