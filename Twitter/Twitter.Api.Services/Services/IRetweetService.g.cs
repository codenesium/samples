using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IRetweetService
	{
		Task<CreateResponse<ApiRetweetServerResponseModel>> Create(
			ApiRetweetServerRequestModel model);

		Task<UpdateResponse<ApiRetweetServerResponseModel>> Update(int id,
		                                                            ApiRetweetServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRetweetServerResponseModel> Get(int id);

		Task<List<ApiRetweetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiRetweetServerResponseModel>> ByRetwitterUserId(int? retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetServerResponseModel>> ByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0548a8f4114024b3f9ffe703673d9753</Hash>
</Codenesium>*/