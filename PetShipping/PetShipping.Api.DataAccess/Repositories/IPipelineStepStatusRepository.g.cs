using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepStatusRepository
	{
		Task<PipelineStepStatus> Create(PipelineStepStatus item);

		Task Update(PipelineStepStatus item);

		Task Delete(int id);

		Task<PipelineStepStatus> Get(int id);

		Task<List<PipelineStepStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStep>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7d3267d003776f33e447e64bfbb03e02</Hash>
</Codenesium>*/