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

		Task<List<HandlerPipelineStep>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<OtherTransport>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepDestination>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<PipelineStepStatus> GetPipelineStepStatus(int pipelineStepStatusId);

		Task<Employee> GetEmployee(int shipperId);
	}
}

/*<Codenesium>
    <Hash>81befd49126f7045a5684d7be83744db</Hash>
</Codenesium>*/