using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepNoteRepository
	{
		Task<PipelineStepNote> Create(PipelineStepNote item);

		Task Update(PipelineStepNote item);

		Task Delete(int id);

		Task<PipelineStepNote> Get(int id);

		Task<List<PipelineStepNote>> All(int limit = int.MaxValue, int offset = 0);

		Task<Employee> GetEmployee(int employeeId);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>924be84442aed12515f88b467c089e44</Hash>
</Codenesium>*/