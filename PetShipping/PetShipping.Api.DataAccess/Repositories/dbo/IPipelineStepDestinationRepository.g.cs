using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		Task<DTOPipelineStepDestination> Create(DTOPipelineStepDestination dto);

		Task Update(int id,
		            DTOPipelineStepDestination dto);

		Task Delete(int id);

		Task<DTOPipelineStepDestination> Get(int id);

		Task<List<DTOPipelineStepDestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>802c3f9ce4a1960b9c618371ab857332</Hash>
</Codenesium>*/