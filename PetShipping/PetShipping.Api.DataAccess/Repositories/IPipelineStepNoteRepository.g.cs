using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepNoteRepository
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
    <Hash>c85f49244d7828ee7d2294442b733d8e</Hash>
</Codenesium>*/