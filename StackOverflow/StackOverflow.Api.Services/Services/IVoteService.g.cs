using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVoteService
	{
		Task<CreateResponse<ApiVoteServerResponseModel>> Create(
			ApiVoteServerRequestModel model);

		Task<UpdateResponse<ApiVoteServerResponseModel>> Update(int id,
		                                                         ApiVoteServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteServerResponseModel> Get(int id);

		Task<List<ApiVoteServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVoteServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>72824d91e607ff00d257a65e27edf122</Hash>
</Codenesium>*/