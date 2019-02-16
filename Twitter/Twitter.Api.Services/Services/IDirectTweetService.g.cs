using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDirectTweetService
	{
		Task<CreateResponse<ApiDirectTweetServerResponseModel>> Create(
			ApiDirectTweetServerRequestModel model);

		Task<UpdateResponse<ApiDirectTweetServerResponseModel>> Update(int tweetId,
		                                                                ApiDirectTweetServerRequestModel model);

		Task<ActionResponse> Delete(int tweetId);

		Task<ApiDirectTweetServerResponseModel> Get(int tweetId);

		Task<List<ApiDirectTweetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiDirectTweetServerResponseModel>> ByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>75bac3b383ad84321441c08442e3e81d</Hash>
</Codenesium>*/