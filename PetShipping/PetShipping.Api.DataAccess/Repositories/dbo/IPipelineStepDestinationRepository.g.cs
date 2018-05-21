using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		Task<POCOPipelineStepDestination> Create(ApiPipelineStepDestinationModel model);

		Task Update(int id,
		            ApiPipelineStepDestinationModel model);

		Task Delete(int id);

		Task<POCOPipelineStepDestination> Get(int id);

		Task<List<POCOPipelineStepDestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>66693561467f5de5894207b9f63e4661</Hash>
</Codenesium>*/