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
	}
}

/*<Codenesium>
    <Hash>705b21a6143207b4f0f1357b2ecde9b8</Hash>
</Codenesium>*/