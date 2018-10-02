using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostLinkService
	{
		Task<CreateResponse<ApiPostLinkResponseModel>> Create(
			ApiPostLinkRequestModel model);

		Task<UpdateResponse<ApiPostLinkResponseModel>> Update(int id,
		                                                       ApiPostLinkRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostLinkResponseModel> Get(int id);

		Task<List<ApiPostLinkResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8fceda1c33f422f3b9fdcd1a32871429</Hash>
</Codenesium>*/