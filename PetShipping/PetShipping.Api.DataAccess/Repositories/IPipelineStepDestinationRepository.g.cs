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

		Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Destination> DestinationByDestinationId(int destinationId);

		Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>7d3b763decb50eca35d0ee89d2ce993e</Hash>
</Codenesium>*/