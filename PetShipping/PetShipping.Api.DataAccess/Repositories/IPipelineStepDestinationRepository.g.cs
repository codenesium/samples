using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepDestinationRepository
	{
		Task<PipelineStepDestination> Create(PipelineStepDestination item);

		Task Update(PipelineStepDestination item);

		Task Delete(int id);

		Task<PipelineStepDestination> Get(int id);

		Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset = 0);

		Task<Destination> GetDestination(int destinationId);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>75b781120a552c58e53c52bf46ed4825</Hash>
</Codenesium>*/