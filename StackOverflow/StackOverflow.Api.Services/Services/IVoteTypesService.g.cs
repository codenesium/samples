using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVoteTypesService
	{
		Task<CreateResponse<ApiVoteTypesServerResponseModel>> Create(
			ApiVoteTypesServerRequestModel model);

		Task<UpdateResponse<ApiVoteTypesServerResponseModel>> Update(int id,
		                                                              ApiVoteTypesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteTypesServerResponseModel> Get(int id);

		Task<List<ApiVoteTypesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVotesServerResponseModel>> VotesByVoteTypeId(int voteTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d1f6b4c7689fc9af50340fdce4580c1a</Hash>
</Codenesium>*/