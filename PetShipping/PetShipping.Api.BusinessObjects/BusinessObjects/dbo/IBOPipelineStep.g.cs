using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStep
	{
		Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
			ApiPipelineStepRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepResponseModel> Get(int id);

		Task<List<ApiPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6598e09541a8c35149a4fff7f0c585a3</Hash>
</Codenesium>*/