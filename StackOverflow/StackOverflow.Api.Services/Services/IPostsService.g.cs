using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostsService
	{
		Task<CreateResponse<ApiPostsResponseModel>> Create(
			ApiPostsRequestModel model);

		Task<UpdateResponse<ApiPostsResponseModel>> Update(int id,
		                                                    ApiPostsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostsResponseModel> Get(int id);

		Task<List<ApiPostsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ad6c09fb43e860ae42fcd6ee1aaa0544</Hash>
</Codenesium>*/