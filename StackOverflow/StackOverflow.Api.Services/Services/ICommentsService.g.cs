using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ICommentsService
	{
		Task<CreateResponse<ApiCommentsServerResponseModel>> Create(
			ApiCommentsServerRequestModel model);

		Task<UpdateResponse<ApiCommentsServerResponseModel>> Update(int id,
		                                                             ApiCommentsServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCommentsServerResponseModel> Get(int id);

		Task<List<ApiCommentsServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCommentsServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCommentsServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f0fda6319ebe07c7238e7b95c7dfb4ca</Hash>
</Codenesium>*/