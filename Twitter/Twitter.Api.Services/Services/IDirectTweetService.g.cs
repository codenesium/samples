using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDirectTweetService
	{
		Task<CreateResponse<ApiDirectTweetResponseModel>> Create(
			ApiDirectTweetRequestModel model);

		Task<UpdateResponse<ApiDirectTweetResponseModel>> Update(int tweetId,
		                                                          ApiDirectTweetRequestModel model);

		Task<ActionResponse> Delete(int tweetId);

		Task<ApiDirectTweetResponseModel> Get(int tweetId);

		Task<List<ApiDirectTweetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDirectTweetResponseModel>> ByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>841601ada1d86945fdaac3075aabbdc6</Hash>
</Codenesium>*/