using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOHandler
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
    <Hash>d53bc0227fb422f0e3e41a4e5954f38d</Hash>
</Codenesium>*/