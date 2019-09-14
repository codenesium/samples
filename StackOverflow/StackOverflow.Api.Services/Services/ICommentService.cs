using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ICommentService
	{
		Task<CreateResponse<ApiCommentServerResponseModel>> Create(
			ApiCommentServerRequestModel model);

		Task<UpdateResponse<ApiCommentServerResponseModel>> Update(int id,
		                                                            ApiCommentServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCommentServerResponseModel> Get(int id);

		Task<List<ApiCommentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCommentServerResponseModel>> ByPostId(int postId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCommentServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ef2b7d7b3e1b4796a9e65ce13930575a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/