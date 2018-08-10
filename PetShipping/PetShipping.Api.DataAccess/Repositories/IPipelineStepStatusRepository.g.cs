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
    <Hash>28d8bc2495c3bc60bdc6e4779581ce4a</Hash>
</Codenesium>*/