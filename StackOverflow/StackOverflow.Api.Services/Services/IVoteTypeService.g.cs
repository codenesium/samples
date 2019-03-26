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

		Task<List<ApiVoteServerResponseModel>> VotesByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>de54602c912ff2f9f33c62021fc8913b</Hash>
</Codenesium>*/