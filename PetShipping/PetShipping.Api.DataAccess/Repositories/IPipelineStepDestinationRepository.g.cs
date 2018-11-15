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

		Task<Destination> DestinationByDestinationId(int destinationId);

		Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>b29f1e7991a56f35ed9a0510d4497eda</Hash>
</Codenesium>*/