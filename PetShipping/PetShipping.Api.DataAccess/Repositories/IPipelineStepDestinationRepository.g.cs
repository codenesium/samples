using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		Task<PipelineStepDestination> Create(PipelineStepDestination item);

		Task Update(PipelineStepDestination item);

		Task Delete(int id);

		Task<PipelineStepDestination> Get(int id);

		Task<List<PipelineStepDestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7be14a34bf139c2bdf493e7a597a0990</Hash>
</Codenesium>*/