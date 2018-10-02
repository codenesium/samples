using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IReplyService
	{
		Task<CreateResponse<ApiReplyResponseModel>> Create(
			ApiReplyRequestModel model);

		Task<UpdateResponse<ApiReplyResponseModel>> Update(int replyId,
		                                                    ApiReplyRequestModel model);

		Task<ActionResponse> Delete(int replyId);

		Task<ApiReplyResponseModel> Get(int replyId);

		Task<List<ApiReplyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiReplyResponseModel>> ByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0f8d0eb6bd832775764ec729ca84c5ea</Hash>
</Codenesium>*/