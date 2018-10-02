using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IRetweetService
	{
		Task<CreateResponse<ApiRetweetResponseModel>> Create(
			ApiRetweetRequestModel model);

		Task<UpdateResponse<ApiRetweetResponseModel>> Update(int id,
		                                                      ApiRetweetRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRetweetResponseModel> Get(int id);

		Task<List<ApiRetweetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetResponseModel>> ByRetwitterUserId(int? retwitterUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRetweetResponseModel>> ByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>08fa5092a2ec735ffed28c8bb0a53d5f</Hash>
</Codenesium>*/