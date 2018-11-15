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

		Task<List<ApiVoteTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f3d80f209cca60a99409891be6be74c4</Hash>
</Codenesium>*/