using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVoteTypeService
	{
		Task<CreateResponse<ApiVoteTypeServerResponseModel>> Create(
			ApiVoteTypeServerRequestModel model);

		Task<UpdateResponse<ApiVoteTypeServerResponseModel>> Update(int id,
		                                                             ApiVoteTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteTypeServerResponseModel> Get(int id);

		Task<List<ApiVoteTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6e0f2c47b5dae2e0b6a4b90a503ff27a</Hash>
</Codenesium>*/