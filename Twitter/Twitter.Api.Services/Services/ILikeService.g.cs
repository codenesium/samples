using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface ILikeService
	{
		Task<CreateResponse<ApiLikeResponseModel>> Create(
			ApiLikeRequestModel model);

		Task<UpdateResponse<ApiLikeResponseModel>> Update(int likeId,
		                                                   ApiLikeRequestModel model);

		Task<ActionResponse> Delete(int likeId);

		Task<ApiLikeResponseModel> Get(int likeId);

		Task<List<ApiLikeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLikeResponseModel>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLikeResponseModel>> ByTweetId(int tweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e9682a65ad36e9e19e320f32935dd9c7</Hash>
</Codenesium>*/