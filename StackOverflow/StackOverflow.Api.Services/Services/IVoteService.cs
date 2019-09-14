using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVoteService
	{
		Task<CreateResponse<ApiVoteServerResponseModel>> Create(
			ApiVoteServerRequestModel model);

		Task<UpdateResponse<ApiVoteServerResponseModel>> Update(int id,
		                                                         ApiVoteServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteServerResponseModel> Get(int id);

		Task<List<ApiVoteServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVoteServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVoteServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVoteServerResponseModel>> ByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>30652e9c6acac655e9c8d9419fa92f1f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/