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

		Task<List<HandlerPipelineStep>> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<OtherTransport>> OtherTransportsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepDestination>> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<PipelineStepStatu> PipelineStepStatuByPipelineStepStatusId(int pipelineStepStatusId);

		Task<Employee> EmployeeByShipperId(int shipperId);
	}
}

/*<Codenesium>
    <Hash>9fd36c4fea0e9a5665eff9946623fbe1</Hash>
</Codenesium>*/