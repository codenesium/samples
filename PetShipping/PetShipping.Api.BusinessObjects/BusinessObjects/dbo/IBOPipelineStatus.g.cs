using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStatus
	{
		Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStatusResponseModel> Get(int id);

		Task<List<ApiPipelineStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0b4f0dac3b346d545e2aed8154779bdb</Hash>
</Codenesium>*/