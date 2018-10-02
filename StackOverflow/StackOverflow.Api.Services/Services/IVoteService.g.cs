using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVoteService
	{
		Task<CreateResponse<ApiVoteResponseModel>> Create(
			ApiVoteRequestModel model);

		Task<UpdateResponse<ApiVoteResponseModel>> Update(int id,
		                                                   ApiVoteRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteResponseModel> Get(int id);

		Task<List<ApiVoteResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVoteResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>442227ef89e7d94a6bf9afc66163c9b4</Hash>
</Codenesium>*/