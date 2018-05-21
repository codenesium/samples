using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
	{
		Task<POCOHandlerPipelineStep> Create(ApiHandlerPipelineStepModel model);

		Task Update(int id,
		            ApiHandlerPipelineStepModel model);

		Task Delete(int id);

		Task<POCOHandlerPipelineStep> Get(int id);

		Task<List<POCOHandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5833b0e657756fab7360960c6f2692ee</Hash>
</Codenesium>*/