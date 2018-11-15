using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IReplyService
	{
		Task<CreateResponse<ApiReplyServerResponseModel>> Create(
			ApiReplyServerRequestModel model);

		Task<UpdateResponse<ApiReplyServerResponseModel>> Update(int replyId,
		                                                          ApiReplyServerRequestModel model);

		Task<ActionResponse> Delete(int replyId);

		Task<ApiReplyServerResponseModel> Get(int replyId);

		Task<List<ApiReplyServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiReplyServerResponseModel>> ByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7fc850dc75354fef8f51ad7d65c34936</Hash>
</Codenesium>*/