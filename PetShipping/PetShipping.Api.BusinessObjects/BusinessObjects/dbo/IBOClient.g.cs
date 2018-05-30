using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOClient
	{
		Task<CreateResponse<ApiClientResponseModel>> Create(
			ApiClientRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiClientRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClientResponseModel> Get(int id);

		Task<List<ApiClientResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>458235285b79bbda6f8efb98e2ce4168</Hash>
</Codenesium>*/