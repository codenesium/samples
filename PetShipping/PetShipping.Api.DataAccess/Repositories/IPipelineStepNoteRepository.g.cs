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

		Task<List<PipelineStepNote>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Employee> EmployeeByEmployeeId(int employeeId);

		Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>b1f2aba642131261a1fc45470fd6e1ca</Hash>
</Codenesium>*/