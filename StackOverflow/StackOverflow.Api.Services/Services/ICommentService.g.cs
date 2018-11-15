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

		Task<List<ApiCommentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f84b4343da9436e2b3ad9d89fc6027c2</Hash>
</Codenesium>*/