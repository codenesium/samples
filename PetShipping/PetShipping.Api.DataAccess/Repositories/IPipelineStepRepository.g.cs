using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepRepository
	{
		Task<PipelineStep> Create(PipelineStep item);

		Task Update(PipelineStep item);

		Task Delete(int id);

		Task<PipelineStep> Get(int id);

		Task<List<PipelineStep>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<PipelineStepStatu> PipelineStepStatuByPipelineStepStatusId(int pipelineStepStatusId);

		Task<Employee> EmployeeByShipperId(int shipperId);

		Task<List<PipelineStep>> ByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9e6c7334b2174702179e3c3b4ac14935</Hash>
</Codenesium>*/