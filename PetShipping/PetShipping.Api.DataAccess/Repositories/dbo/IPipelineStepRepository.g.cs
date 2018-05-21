using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		Task<POCOPipelineStep> Create(ApiPipelineStepModel model);

		Task Update(int id,
		            ApiPipelineStepModel model);

		Task Delete(int id);

		Task<POCOPipelineStep> Get(int id);

		Task<List<POCOPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>51e2e37bb0c73f6b9e0a82f50b72220a</Hash>
</Codenesium>*/