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

		Task<List<PipelineStep>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<HandlerPipelineStep>> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<OtherTransport>> OtherTransportsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepDestination>> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<PipelineStepStatus> PipelineStepStatusByPipelineStepStatusId(int pipelineStepStatusId);

		Task<Employee> EmployeeByShipperId(int shipperId);
	}
}

/*<Codenesium>
    <Hash>617c41461ada38e6041c2ef290d7c274</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/