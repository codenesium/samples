using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostService
	{
		Task<CreateResponse<ApiPostResponseModel>> Create(
			ApiPostRequestModel model);

		Task<UpdateResponse<ApiPostResponseModel>> Update(int id,
		                                                   ApiPostRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostResponseModel> Get(int id);

		Task<List<ApiPostResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPostResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>814f6d1615d658191caec79d23aa0c6c</Hash>
</Codenesium>*/