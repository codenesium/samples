using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
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
    <Hash>f620d445f4697611939d5ed2602d23ac</Hash>
</Codenesium>*/