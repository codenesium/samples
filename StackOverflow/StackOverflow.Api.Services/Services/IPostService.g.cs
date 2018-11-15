using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostService
	{
		Task<CreateResponse<ApiPostServerResponseModel>> Create(
			ApiPostServerRequestModel model);

		Task<UpdateResponse<ApiPostServerResponseModel>> Update(int id,
		                                                         ApiPostServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostServerResponseModel> Get(int id);

		Task<List<ApiPostServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostServerResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>006cef99d027ebe167f59e3619562f16</Hash>
</Codenesium>*/