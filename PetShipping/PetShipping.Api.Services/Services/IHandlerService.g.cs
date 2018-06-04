using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IHandlerService
	{
		Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiHandlerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerResponseModel> Get(int id);

		Task<List<ApiHandlerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e5112bb6c8fcf1d7343506d975135896</Hash>
</Codenesium>*/