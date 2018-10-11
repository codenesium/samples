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

		Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>c54df74c91ef358fcc9731eee39b1b89</Hash>
</Codenesium>*/