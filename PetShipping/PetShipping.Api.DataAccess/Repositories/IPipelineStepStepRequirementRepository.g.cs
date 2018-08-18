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
    <Hash>514aee5b9e3c833080eceb5bba9513f6</Hash>
</Codenesium>*/