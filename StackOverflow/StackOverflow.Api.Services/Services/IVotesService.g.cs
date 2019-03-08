using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVotesService
	{
		Task<CreateResponse<ApiVotesServerResponseModel>> Create(
			ApiVotesServerRequestModel model);

		Task<UpdateResponse<ApiVotesServerResponseModel>> Update(int id,
		                                                          ApiVotesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVotesServerResponseModel> Get(int id);

		Task<List<ApiVotesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVotesServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVotesServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVotesServerResponseModel>> ByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ddd561595f9828f4790e872c8f1c84c1</Hash>
</Codenesium>*/