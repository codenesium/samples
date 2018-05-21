using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepStatus
	{
		Task<CreateResponse<POCOPipelineStepStatus>> Create(
			ApiPipelineStepStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepStatusModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPipelineStepStatus> Get(int id);

		Task<List<POCOPipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>85d85495d2eceb0062e8d962ac2ca77f</Hash>
</Codenesium>*/