using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IPipelineService
	{
		Task<CreateResponse<ApiPipelineResponseModel>> Create(
			ApiPipelineRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineResponseModel> Get(int id);

		Task<List<ApiPipelineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c33e1761ec552a7891c7201622a3a89b</Hash>
</Codenesium>*/